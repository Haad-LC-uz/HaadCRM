using HaadCRM.Service.DTOs.EmployeeDTOs.EmployeeRoles; // Import the necessary DTO namespace

namespace HaadCRM.Service.Services.EmployeeRoles;

/// <summary>
/// Service interface for managing employee roles.
/// </summary>
public interface IEmployeeRoleService
{
    /// <summary>
    /// Creates a new employee role.
    /// </summary>
    /// <param name="createModel">The model containing data for creating the employee role.</param>
    /// <returns>The created employee role view model.</returns>
    ValueTask<EmployeeRoleViewModel> CreateAsync(EmployeeRoleCreateModel createModel);

    /// <summary>
    /// Deletes an existing employee role by its ID.
    /// </summary>
    /// <param name="id">The ID of the employee role to delete.</param>
    /// <returns>A boolean indicating whether the deletion was successful.</returns>
    ValueTask<bool> DeleteAsync(long id);

    /// <summary>
    /// Retrieves all employee roles.
    /// </summary>
    /// <returns>A collection of all employee role view models.</returns>
    ValueTask<IEnumerable<EmployeeRoleViewModel>> GetAllAsync();

    /// <summary>
    /// Retrieves an employee role by its ID.
    /// </summary>
    /// <param name="id">The ID of the employee role to retrieve.</param>
    /// <returns>The employee role view model corresponding to the provided ID.</returns>
    ValueTask<EmployeeRoleViewModel> GetByIdAsync(long id);

    /// <summary>
    /// Updates an existing employee role.
    /// </summary>
    /// <param name="id">The ID of the employee role to update.</param>
    /// <param name="updateModel">The model containing data for updating the employee role.</param>
    /// <returns>The updated employee role view model.</returns>
    ValueTask<EmployeeRoleViewModel> UpdateAsync(long id, EmployeeRoleUpdateModel updateModel);
}
