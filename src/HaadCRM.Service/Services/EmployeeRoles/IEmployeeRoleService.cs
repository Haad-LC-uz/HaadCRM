using HaadCRM.Service.DTOs.EmployeeDTOs.EmployeeRoles;

namespace HaadCRM.Service.Services.EmployeeRoles
{
    public interface IEmployeeRoleService
    {
        ValueTask<EmployeeRoleViewModel> CreateAsync(EmployeeRoleCreateModel createModel);
        ValueTask<bool> DeleteAsync(long id);
        ValueTask<IEnumerable<EmployeeRoleViewModel>> GetAllAsync();
        ValueTask<EmployeeRoleViewModel> GetByIdAsync(long id);
        ValueTask<EmployeeRoleViewModel> UpdateAsync(long id, EmployeeRoleUpdateModel updateModel);
    }
}