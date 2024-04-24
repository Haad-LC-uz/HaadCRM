using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.EmployeeDTOs.Employees;
using HaadCRM.Service.Exceptions;
using HaadCRM.Service.Extensions;
using HaadCRM.Service.Validators.Employees.EmployeeRoles;
using HaadCRM.Service.Validators.Employees.Employees;

namespace HaadCRM.Service.Services.Employees;

public class EmployeeService(
    IUnitOfWork unitOfWork, 
    IMapper mapper,
    EmployeeCreateModelValidator createModelValidator,
    EmployeeUpdateModelValidator updateModelValidator) : IEmployeeService
{

    // Creates a new employee
    public async ValueTask<EmployeeViewModel> CreateAsync(EmployeeCreateModel createModel)
    {
        await createModelValidator.ValidateOrPanicAsync(createModel);

        // Check if an employee with the same user ID already exists
        var existEmployee = await unitOfWork.Employees.SelectAsync(employee => employee.UserId == createModel.UserId);
        if (existEmployee != null)
        {
            throw new AlreadyExistException("An employee with the same user ID already exists.");
        }

        // Map the createModel to an Employee entity
        var employee = mapper.Map<Employee>(createModel);

        // Retrieve the associated employee role based on the provided ID
        employee.EmployeeRole = await unitOfWork.EmployeeRoles.SelectAsync(id => id.Id == createModel.EmployeeRoleId);

        // Insert the new employee into the database
        var createdEmployee = await unitOfWork.Employees.InsertAsync(employee);
        await unitOfWork.SaveAsync();

        // Map the created employee back to a view model and return
        return mapper.Map<EmployeeViewModel>(createdEmployee);
    }

    // Updates an existing employee
    public async ValueTask<EmployeeViewModel> UpdateAsync(long id, EmployeeUpdateModel updateModel)
    {
        await updateModelValidator.ValidateOrPanicAsync(updateModel);

        // Find the employee by ID, throw NotFoundException if not found
        var employee = await unitOfWork.Employees.SelectAsync(emp => emp.Id == id)
            ?? throw new NotFoundException($"Employee is not found with this ID={id}");

        // Map properties from updateModel to the retrieved employee entity
        mapper.Map(updateModel, employee);

        // Update the employee in the database
        await unitOfWork.Employees.UpdateAsync(employee);
        await unitOfWork.SaveAsync();

        // Map the updated employee back to a view model and return
        return mapper.Map<EmployeeViewModel>(employee);
    }

    // Deletes an employee by ID
    public async ValueTask<bool> DeleteAsync(long id)
    {
        // Find the employee by ID, throw NotFoundException if not found
        var employee = await unitOfWork.Employees.SelectAsync(emp => emp.Id == id)
            ?? throw new NotFoundException($"Employee is not found with this ID={id}");

        // Delete the employee from the database
        await unitOfWork.Employees.DeleteAsync(employee);
        await unitOfWork.SaveAsync();

        return true; // Deletion successful
    }

    // Gets all employees
    public async ValueTask<IEnumerable<EmployeeViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        // Retrieve all employees from the database
        var employees = unitOfWork.Employees.SelectAsQueryable(expression: emp => emp.IsDeleted, isTracked: false);

        // Map the list of employees to a list of view models and return
        return mapper.Map<IEnumerable<EmployeeViewModel>>(employees);
    }

    // Gets an employee by ID
    public async ValueTask<EmployeeViewModel> GetByIdAsync(long id)
    {
        // Find the employee by ID, throw NotFoundException if not found
        var employee = await unitOfWork.Employees.SelectAsync(emp => emp.Id == id)
            ?? throw new NotFoundException($"Employee is not found with this ID={id}");

        // Map the retrieved employee to a view model and return
        return mapper.Map<EmployeeViewModel>(employee);
    }
}
