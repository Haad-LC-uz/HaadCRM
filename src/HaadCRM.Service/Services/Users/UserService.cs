using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Users;
using HaadCRM.Service.DTOs.UserDTOs.Users;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.Users;

public class UserService(IUnitOfWork unitOfWork, IMapper mapper) : IUserService
{
    public async ValueTask<UserViewModel> CreateAsync(UserCreateModel createModel)
    {
        var existingUser = await unitOfWork.Users.SelectAsync(user =>
            user.Email == createModel.Email || user.Phone == createModel.Phone);

        if (existingUser != null)
        {
            throw new AlreadyExistException("A user with the same email or phone already exists.");
        }

        var user = mapper.Map<User>(createModel);

        var userRole = await unitOfWork.UserRoles.SelectAsync(role => role.Id == createModel.UserRoleId)
            ?? throw new NotFoundException($"UserRole is not found with ID={createModel.UserRoleId}");

        user.UserRole = userRole;

        var createdUser = await unitOfWork.Users.InsertAsync(user);
        await unitOfWork.SaveAsync();

        return mapper.Map<UserViewModel>(createdUser);
    }

    public async ValueTask<UserViewModel> UpdateAsync(long id, UserUpdateModel updateModel)
    {
        var user = await unitOfWork.Users.SelectAsync(user => user.Id == id) 
            ?? throw new NotFoundException($"User is not found with ID={id}");
        mapper.Map(updateModel, user);

        await unitOfWork.Users.UpdateAsync(user);
        await unitOfWork.SaveAsync();

        return mapper.Map<UserViewModel>(user);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var user = await unitOfWork.Users.SelectAsync(user => user.Id == id) 
            ?? throw new NotFoundException($"User is not found with ID={id}");
        await unitOfWork.Users.DeleteAsync(user);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<UserViewModel>> GetAllAsync()
    {
        var users = await unitOfWork.Users.SelectAsEnumerableAsync();
        return mapper.Map<IEnumerable<UserViewModel>>(users);
    }

    public async ValueTask<UserViewModel> GetByIdAsync(long id)
    {
        var user = await unitOfWork.Users.SelectAsync(user => user.Id == id) 
            ?? throw new NotFoundException($"User is not found with ID={id}");
        return mapper.Map<UserViewModel>(user);
    }
}
