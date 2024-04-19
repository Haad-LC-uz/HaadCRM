using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Service.DTOs.EmployeeDTOs.Employees;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.Employees;

public class EmployeeService(IUnitOfWork unitOfWork, IMapper mapper)
{
    public async ValueTask<EmployeeViewModel> CreateAsync(EmployeeCreateModel createModel)
    {
        var existEmployee = await unitOfWork.Employees.SelectAsync(Employee => 
            Employee.UserId == createModel.UserId);

        if (existEmployee != null)
        {
            throw new AlreadyExistException("A user with the same email or phone already exists.");
        }

        var employee = mapper.Map<Employee>(createModel);

        employee.EmployeeRole = await unitOfWork.EmployeeRoles.SelectAsync(id => id.Id == createModel.EmployeeRoleId);

        var createdEmloyee = await unitOfWork.Employees.InsertAsync(employee);

        await unitOfWork.SaveAsync();

        return mapper.Map<EmployeeViewModel>(createdEmloyee);
    }
}
