using HaadCRM.Service.DTOs.EmployeeDTOs.Employees;

namespace HaadCRM.Service.Services.Employees;

/// <summary>
/// Interface defining operations related to employees.
/// </summary>
public interface IEmployeeService
{
    /// <summary>
    /// Creates a new employee based on the provided createModel.
    /// </summary>
    /// <param name="createModel">The model containing data for creating the employee.</param>
    /// <returns>The newly created employee view model.</returns>
    ValueTask<EmployeeViewModel> CreateAsync(EmployeeCreateModel createModel);

    /// <summary>
    /// Deletes an employee with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the employee to delete.</param>
    /// <returns>True if the deletion was successful; otherwise, false.</returns>
    ValueTask<bool> DeleteAsync(long id);

    /// <summary>
    /// Retrieves all employees.
    /// </summary>
    /// <returns>An enumerable collection of employee view models.</returns>
    ValueTask<IEnumerable<EmployeeViewModel>> GetAllAsync();

    /// <summary>
    /// Retrieves an employee by their ID.
    /// </summary>
    /// <param name="id">The ID of the employee to retrieve.</param>
    /// <returns>The employee view model corresponding to the specified ID.</returns>
    ValueTask<EmployeeViewModel> GetByIdAsync(long id);

    /// <summary>
    /// Updates an existing employee with the specified ID using the provided updateModel.
    /// </summary>
    /// <param name="id">The ID of the employee to update.</param>
    /// <param name="updateModel">The model containing updated data for the employee.</param>
    /// <returns>The updated employee view model.</returns>
    ValueTask<EmployeeViewModel> UpdateAsync(long id, EmployeeUpdateModel updateModel);
}
