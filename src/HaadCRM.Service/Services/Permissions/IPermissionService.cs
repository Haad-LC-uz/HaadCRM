using HaadCRM.Service.DTOs.UserDTOs.Permissions;

namespace HaadCRM.Service.Services.Permissions;

public interface IPermissionService
{
    ValueTask<PermissionViewModel> CreateAsync(PermissionCreateModel createModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<PermissionViewModel>> GetAllAsync();
    ValueTask<PermissionViewModel> GetByIdAsync(long id);
    ValueTask<PermissionViewModel> UpdateAsync(long id, PermissionUpdateModel updateModel);
}