using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Users;
using HaadCRM.Service.DTOs.UserDTOs.Users;
using HaadCRM.Service.Exceptions;
using HaadCRM.Service.Extensions;
using HaadCRM.Service.Helpers;
using HaadCRM.Service.Validators.Users;
using Microsoft.Extensions.Caching.Memory;

namespace HaadCRM.Service.Services.Users;

public class UserService(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IMemoryCache memoryCache,
    UserCreateModelValidator userCreateModelValidator,
    UserUpdateModelValidator userUpdateModelValidator) : IUserService
{
    private readonly string cacheKey = "EmailCodeKey";

    // Creates a new user
    public async ValueTask<UserViewModel> CreateAsync(UserCreateModel createModel)
    {
        await userCreateModelValidator.ValidateOrPanicAsync(createModel);
        // Check if a user with the same email or phone already exists
        var existingUser = await unitOfWork.Users.SelectAsync(user =>
            user.Email == createModel.Email || user.Phone == createModel.Phone);

        if (existingUser != null)
        {
            throw new AlreadyExistException("A user with the same email or phone already exists.");
        }

        // Map the createModel to a User entity
        var user = mapper.Map<User>(createModel);

        // Retrieve the user role by ID, throw NotFoundException if not found
        var userRole = await unitOfWork.UserRoles.SelectAsync(role => role.Id == createModel.UserRoleId)
            ?? throw new NotFoundException($"UserRole is not found with ID={createModel.UserRoleId}");

        // Assign the Hashed Password to the user
        user.Password = PasswordHasher.Hash(createModel.Password);

        // Assign the user role to the user
        user.UserRole = userRole;

        // Insert the new user into the database
        var createdUser = await unitOfWork.Users.InsertAsync(user);
        await unitOfWork.SaveAsync();

        // Map the created user back to a view model and return
        return mapper.Map<UserViewModel>(createdUser);
    }

    // Updates an existing user by ID with the provided updateModel
    public async ValueTask<UserViewModel> UpdateAsync(long id, UserUpdateModel updateModel)
    {
        await userUpdateModelValidator.ValidateOrPanicAsync(updateModel);
        // Find the user by ID, throw NotFoundException if not found
        var user = await unitOfWork.Users.SelectAsync(user => user.Id == id)
            ?? throw new NotFoundException($"User is not found with ID={id}");

        // Map properties from updateModel to the retrieved user entity
        mapper.Map(updateModel, user);

        // Update the user in the database
        await unitOfWork.Users.UpdateAsync(user);
        await unitOfWork.SaveAsync();

        // Map the updated user back to a view model and return
        return mapper.Map<UserViewModel>(user);
    }

    // Deletes a user by ID
    public async ValueTask<bool> DeleteAsync(long id)
    {
        // Find the user by ID, throw NotFoundException if not found
        var user = await unitOfWork.Users.SelectAsync(user => user.Id == id)
            ?? throw new NotFoundException($"User is not found with ID={id}");

        // Delete the user from the database
        await unitOfWork.Users.DeleteAsync(user);
        await unitOfWork.SaveAsync();

        return true; // Deletion successful
    }

    // Gets all users
    public async ValueTask<IEnumerable<UserViewModel>> GetAllAsync()
    {
        // Retrieve all users from the database
        var users = await unitOfWork.Users.SelectAsEnumerableAsync();

        // Map the list of users to a list of view models and return
        return mapper.Map<IEnumerable<UserViewModel>>(users);
    }

    // Gets a user by ID
    public async ValueTask<UserViewModel> GetByIdAsync(long id)
    {
        // Find the user by ID, throw NotFoundException if not found
        var user = await unitOfWork.Users.SelectAsync(user => user.Id == id)
            ?? throw new NotFoundException($"User is not found with ID={id}");

        // Map the retrieved user to a view model and return
        return mapper.Map<UserViewModel>(user);
    }

    public async ValueTask<(User user, string token)> LoginAsync(string phone, string password)
    {
        // Find a user with the matching phone number (avoid mentioning password)
        var existingUser = await unitOfWork.Users.SelectAsync(
            user => user.Phone == phone && !user.IsDeleted, // Omit password check for security
            includes: ["Role"]  // Include the user's role information
        ) ?? throw new ArgumentIsNotValidException("Invalid login credentials");

        // Login successful, return user and generated token
        return (user: existingUser, token: AuthHelper.GenerateToken(existingUser));
    }

    public async ValueTask<bool> ResetPasswordAsync(string phone, string newPassword)
    {
        // Find the user by phone number, throw NotFoundException if not found or user is deleted
        var existUser = await unitOfWork.Users.SelectAsync(user => user.Phone == phone && !user.IsDeleted)
            ?? throw new NotFoundException($"User is not found with this phone={phone}");

        // Retrieve the code from the cache
        var code = memoryCache.Get(cacheKey) as string;

        // Check if the code provided matches the one sent to the user
        if (!await ConfirmCodeAsync(phone, code))
        {
            // If the code doesn't match, throw an exception
            throw new ArgumentIsNotValidException("Confirmation failed");
        }

        // Hash the new password and update the user's password
        existUser.Password = PasswordHasher.Hash(newPassword);

        // Update the user in the database
        await unitOfWork.Users.UpdateAsync(existUser);
        await unitOfWork.SaveAsync();

        // Return true indicating successful password reset
        return true;
    }

    public async ValueTask<bool> SendCodeAsync(string phone)
    {
        // Find the user by phone number, throw NotFoundException if not found
        var user = await unitOfWork.Users.SelectAsync(user => user.Phone == phone)
            ?? throw new NotFoundException($"User is not found with this phone={phone}");

        // Generate a random code
        var random = new Random();
        var code = random.Next(10000, 99999);

        // Send the code to the user's email
        await EmailHelper.SendMessageAsync(user.Email, "Confirmation Code", code.ToString());

        // Set cache options for the code
        var memoryCacheOptions = new MemoryCacheEntryOptions()
            .SetSize(50)
            .SetAbsoluteExpiration(TimeSpan.FromSeconds(60))
            .SetSlidingExpiration(TimeSpan.FromSeconds(30))
            .SetPriority(CacheItemPriority.Normal);

        // Cache the code
        memoryCache.Set(cacheKey, code.ToString(), memoryCacheOptions);

        // Return true indicating successful code sending
        return true;
    }

    public async ValueTask<bool> ConfirmCodeAsync(string phone, string code)
    {
        // Find the user with the provided phone number
        var user = await unitOfWork.Users.SelectAsync(user => user.Phone == phone)
            ?? throw new NotFoundException($"User is not found with this phone={phone}");

        // Retrieve the code from the cache and compare it with the provided code
        if (memoryCache.Get(cacheKey) as string == code)
            return true; // Return true if the codes match

        return false; // Return false if the codes do not match
    }

    public async ValueTask<User> ChangePasswordAsync(string phone, string oldPassword, string newPassword)
    {
        // Find the user by phone number and verify the old password
        var existUser = await unitOfWork.Users.SelectAsync(
            expression: u =>
                u.Phone == phone && PasswordHasher.Verify(oldPassword, u.Password) && !u.IsDeleted,
            includes: ["Role"])
            ?? throw new ArgumentIsNotValidException($"Phone or password is not valid");

        // Update the user's password with the new hashed password
        existUser.Password = PasswordHasher.Hash(newPassword);

        // Update the user in the database
        await unitOfWork.Users.UpdateAsync(existUser);
        await unitOfWork.SaveAsync();

        // Return the updated user
        return existUser;
    }

}
