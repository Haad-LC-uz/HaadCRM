using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Service.DTOs.EmployeeDTOs.EmployeeRoles;
using HaadCRM.Service.Exceptions;
using HaadCRM.Service.Extensions;
using HaadCRM.Service.Validators.Employees.EmployeeRoles;

namespace HaadCRM.Service.Services.EmployeeRoles;

public class EmployeeRoleService(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    EmployeeRoleCreateModelValidator createModelValidator,
    EmployeeRoleUpdateModelValidator updateModelValidator) : IEmployeeRoleService
{

    // Creates a new employee role
    public async ValueTask<EmployeeRoleViewModel> CreateAsync(EmployeeRoleCreateModel createModel)
    {
        await createModelValidator.ValidateOrPanicAsync(createModel);
        // Check if an employee role with the same name already exists
        var existingRole = await unitOfWork.EmployeeRoles.SelectAsync(role => role.Name == createModel.Name);
        if (existingRole != null)
        {
            throw new AlreadyExistException("An employee role with the same name already exists.");
        }

        // Map the createModel to an EmployeeRole entity
        var employeeRole = mapper.Map<EmployeeRole>(createModel);

        // Insert the new employee role into the database
        var createdEmployeeRole = await unitOfWork.EmployeeRoles.InsertAsync(employeeRole);
        await unitOfWork.SaveAsync();

        // Map the created employee role back to a view model and return
        return mapper.Map<EmployeeRoleViewModel>(createdEmployeeRole);
    }

    // Updates an existing employee role
    public async ValueTask<EmployeeRoleViewModel> UpdateAsync(long id, EmployeeRoleUpdateModel updateModel)
    {
        await updateModelValidator.ValidateOrPanicAsync(updateModel);
        // Find the employee role by ID, throw NotFoundException if not found
        var employeeRole = await unitOfWork.EmployeeRoles.SelectAsync(role => role.Id == id)
            ?? throw new NotFoundException($"Employee role is not found with this ID={id}");

        // Map properties from updateModel to the retrieved employeeRole entity
        mapper.Map(updateModel, employeeRole);

        // Update the employee role in the database
        await unitOfWork.EmployeeRoles.UpdateAsync(employeeRole);
        await unitOfWork.SaveAsync();

        // Map the updated employee role back to a view model and return
        return mapper.Map<EmployeeRoleViewModel>(employeeRole);
    }

    // Deletes an employee role by ID
    public async ValueTask<bool> DeleteAsync(long id)
    {
        // Find the employee role by ID, throw NotFoundException if not found
        var employeeRole = await unitOfWork.EmployeeRoles.SelectAsync(role => role.Id == id)
            ?? throw new NotFoundException($"Employee role is not found with this ID={id}");

        // Delete the employee role from the database
        await unitOfWork.EmployeeRoles.DeleteAsync(employeeRole);
        await unitOfWork.SaveAsync();

        return true; // Deletion successful
    }

    // Gets all employee roles
    public async ValueTask<IEnumerable<EmployeeRoleViewModel>> GetAllAsync()
    {
        // Retrieve all employee roles from the database
        var employeeRoles = await unitOfWork.EmployeeRoles.SelectAsEnumerableAsync();

        // Map the list of employee roles to a list of view models and return
        return mapper.Map<IEnumerable<EmployeeRoleViewModel>>(employeeRoles);
    }

    // Gets an employee role by ID
    public async ValueTask<EmployeeRoleViewModel> GetByIdAsync(long id)
    {
        // Find the employee role by ID, throw NotFoundException if not found
        var employeeRole = await unitOfWork.EmployeeRoles.SelectAsync(role => role.Id == id)
            ?? throw new NotFoundException($"Employee role is not found with this ID={id}");

        // Map the retrieved employee role to a view model and return
        return mapper.Map<EmployeeRoleViewModel>(employeeRole);
    }
}
