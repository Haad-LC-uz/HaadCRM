using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Users;
using HaadCRM.Service.DTOs.UserDTOs.Users;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        // Creates a new user
        public async ValueTask<UserViewModel> CreateAsync(UserCreateModel createModel)
        {
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
    }
}
