using HaadCRM.Service.DTOs.UserDTOs.UserRoles;

namespace HaadCRM.Service.Services.UserRoles;

public interface IUserRoleService
{
    ValueTask<UserRoleViewModel> CreateAsync(UserRoleCreateModel createModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<UserRoleViewModel>> GetAllAsync();
    ValueTask<UserRoleViewModel> GetByIdAsync(long id);
    ValueTask<UserRoleViewModel> UpdateAsync(long id, UserRoleUpdateModel updateModel);
}