using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.UserDTOs.UserPermissions;

namespace HaadCRM.Service.Services.UserPermissions;

/// <summary>
/// Interface defining operations related to user permissions.
/// </summary>
public interface IUserPermissionService
{
    /// <summary>
    /// Creates a new user permission based on the provided createModel.
    /// </summary>
    /// <param name="createModel">The model containing data for creating the user permission.</param>
    /// <returns>The newly created user permission view model.</returns>
    ValueTask<UserPermissionViewModel> CreateAsync(UserPermissionCreateModel createModel);

    /// <summary>
    /// Deletes a user permission with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the user permission to delete.</param>
    /// <returns>True if the deletion was successful; otherwise, false.</returns>
    ValueTask<bool> DeleteAsync(long id);

    /// <summary>
    /// Retrieves all user permissions.
    /// </summary>
    /// <returns>An enumerable collection of user permission view models.</returns>
    ValueTask<IEnumerable<UserPermissionViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);

    /// <summary>
    /// Retrieves a user permission by the user ID and permission ID.
    /// </summary>
    /// <param name="userId">The ID of the user.</param>
    /// <param name="permissionId">The ID of the permission.</param>
    /// <returns>The user permission view model corresponding to the specified user ID and permission ID.</returns>
    ValueTask<UserPermissionViewModel> GetByIdAsync(long id);

    /// <summary>
    /// Updates an existing user permission using the provided updateModel.
    /// </summary>
    /// <param name="updateModel">The model containing updated data for the user permission.</param>
    /// <returns>The updated user permission view model.</returns>
    ValueTask<UserPermissionViewModel> UpdateAsync(UserPermissionUpdateModel updateModel);
}
