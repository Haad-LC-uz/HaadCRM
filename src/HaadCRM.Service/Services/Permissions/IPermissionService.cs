using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.UserDTOs.Permissions;

namespace HaadCRM.Service.Services.Permissions;

/// <summary>
/// Interface defining operations related to permissions.
/// </summary>
public interface IPermissionService
{
    /// <summary>
    /// Creates a new permission based on the provided createModel.
    /// </summary>
    /// <param name="createModel">The model containing data for creating the permission.</param>
    /// <returns>The newly created permission view model.</returns>
    ValueTask<PermissionViewModel> CreateAsync(PermissionCreateModel createModel);

    /// <summary>
    /// Deletes a permission with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the permission to delete.</param>
    /// <returns>True if the deletion was successful; otherwise, false.</returns>
    ValueTask<bool> DeleteAsync(long id);

    /// <summary>
    /// Retrieves all permissions.
    /// </summary>
    /// <returns>An enumerable collection of permission view models.</returns>
    ValueTask<IEnumerable<PermissionViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);

    /// <summary>
    /// Retrieves a permission by its ID.
    /// </summary>
    /// <param name="id">The ID of the permission to retrieve.</param>
    /// <returns>The permission view model corresponding to the specified ID.</returns>
    ValueTask<PermissionViewModel> GetByIdAsync(long id);

    /// <summary>
    /// Updates an existing permission with the specified ID using the provided updateModel.
    /// </summary>
    /// <param name="id">The ID of the permission to update.</param>
    /// <param name="updateModel">The model containing updated data for the permission.</param>
    /// <returns>The updated permission view model.</returns>
    ValueTask<PermissionViewModel> UpdateAsync(long id, PermissionUpdateModel updateModel);
}
