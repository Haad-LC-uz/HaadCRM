using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Users;
using HaadCRM.Service.DTOs.UserDTOs.UserPermissions;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.UserPermissions;

public class UserPermissionService(IMapper mapper, IUnitOfWork unitOfWork) : IUserPermissionService
{
    public async ValueTask<UserPermissionViewModel> CreateAsync(UserPermissionCreateModel createModel)
    {
        var existingPermission = await unitOfWork.UserPermissions.SelectAsync(up =>
            up.UserId == createModel.UserId && up.PermissionId == createModel.PermissionId);

        if (existingPermission != null)
        {
            throw new AlreadyExistException("This user permission already exists.");
        }

        var userPermission = mapper.Map<UserPermission>(createModel);
        var createdUserPermission = await unitOfWork.UserPermissions.InsertAsync(userPermission);
        await unitOfWork.SaveAsync();

        return mapper.Map<UserPermissionViewModel>(createdUserPermission);
    }

    public async ValueTask<UserPermissionViewModel> UpdateAsync(UserPermissionUpdateModel updateModel)
    {
        var userPermission = await unitOfWork.UserPermissions.SelectAsync(up =>
            up.UserId == updateModel.UserId && up.PermissionId == updateModel.PermissionId)
            ?? throw new NotFoundException("User permission not found.");
        mapper.Map(updateModel, userPermission);
        await unitOfWork.UserPermissions.UpdateAsync(userPermission);
        await unitOfWork.SaveAsync();

        return mapper.Map<UserPermissionViewModel>(userPermission);
    }


    public async ValueTask<bool> DeleteAsync(long userId, long permissionId)
    {
        var userPermission = await unitOfWork.UserPermissions.SelectAsync(up =>
            up.UserId == userId && up.PermissionId == permissionId)
            ?? throw new NotFoundException("User permission not found.");
        await unitOfWork.UserPermissions.DeleteAsync(userPermission);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<UserPermissionViewModel>> GetAllAsync()
    {
        var userPermissions = await unitOfWork.UserPermissions.SelectAsEnumerableAsync();
        return mapper.Map<IEnumerable<UserPermissionViewModel>>(userPermissions);
    }

    public async ValueTask<UserPermissionViewModel> GetByIdAsync(long userId, long permissionId)
    {
        var userPermission = await unitOfWork.UserPermissions.SelectAsync(up =>
            up.UserId == userId && up.PermissionId == permissionId)
            ?? throw new NotFoundException("User permission not found.");
        return mapper.Map<UserPermissionViewModel>(userPermission);
    }
}
