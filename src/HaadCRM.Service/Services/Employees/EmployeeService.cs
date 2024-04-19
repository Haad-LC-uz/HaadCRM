using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Service.DTOs.EmployeeDTOs.Employees;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.Employees;
public class EmployeeService(IUnitOfWork unitOfWork, IMapper mapper) : IEmployeeService
{
    public async ValueTask<EmployeeViewModel> CreateAsync(EmployeeCreateModel createModel)
    {
        var existEmployee = await unitOfWork.Employees.SelectAsync(employee => employee.UserId == createModel.UserId);

        if (existEmployee != null)
        {
            throw new AlreadyExistException("An employee with the same user ID already exists.");
        }

        var employee = mapper.Map<Employee>(createModel);

        employee.EmployeeRole = await unitOfWork.EmployeeRoles.SelectAsync(id => id.Id == createModel.EmployeeRoleId);

        var createdEmployee = await unitOfWork.Employees.InsertAsync(employee);
        await unitOfWork.SaveAsync();

        return mapper.Map<EmployeeViewModel>(createdEmployee);
    }

    public async ValueTask<EmployeeViewModel> UpdateAsync(long id, EmployeeUpdateModel updateModel)
    {
        var employee = await unitOfWork.Employees.SelectAsync(emp => emp.Id == id)
            ?? throw new NotFoundException($"Employee is not found with this ID={id}");

        mapper.Map(updateModel, employee);

        await unitOfWork.Employees.UpdateAsync(employee);
        await unitOfWork.SaveAsync();

        return mapper.Map<EmployeeViewModel>(employee);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var employee = await unitOfWork.Employees.SelectAsync(emp => emp.Id == id)
            ?? throw new NotFoundException($"Employee is not found with this ID={id}");

        await unitOfWork.Employees.DeleteAsync(employee);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<EmployeeViewModel>> GetAllAsync()
    {
        var employees = await unitOfWork.Employees.SelectAsEnumerableAsync();
        return mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
    }

    public async ValueTask<EmployeeViewModel> GetByIdAsync(long id)
    {
        var employee = await unitOfWork.Employees.SelectAsync(emp => emp.Id == id)
            ?? throw new NotFoundException($"Employee is not found with this ID={id}");

        return mapper.Map<EmployeeViewModel>(employee);
    }
}
