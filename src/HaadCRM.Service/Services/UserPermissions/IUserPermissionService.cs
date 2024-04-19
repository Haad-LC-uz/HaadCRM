using HaadCRM.Service.DTOs.UserDTOs.UserPermissions;

namespace HaadCRM.Service.Services.UserPermissions;

public interface IUserPermissionService
{
    ValueTask<UserPermissionViewModel> CreateAsync(UserPermissionCreateModel createModel);
    ValueTask<bool> DeleteAsync(long userId, long permissionId);
    ValueTask<IEnumerable<UserPermissionViewModel>> GetAllAsync();
    ValueTask<UserPermissionViewModel> GetByIdAsync(long userId, long permissionId);
    ValueTask<UserPermissionViewModel> UpdateAsync(UserPermissionUpdateModel updateModel);
}