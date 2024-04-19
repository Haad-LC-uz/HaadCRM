using HaadCRM.Service.DTOs.EmployeeDTOs.Employees;

namespace HaadCRM.Service.Services.Employees;

public interface IEmployeeService
{
    ValueTask<EmployeeViewModel> CreateAsync(EmployeeCreateModel createModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<EmployeeViewModel>> GetAllAsync();
    ValueTask<EmployeeViewModel> GetByIdAsync(long id);
    ValueTask<EmployeeViewModel> UpdateAsync(long id, EmployeeUpdateModel updateModel);
}