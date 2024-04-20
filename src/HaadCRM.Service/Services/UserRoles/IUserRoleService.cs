using HaadCRM.Service.DTOs.UserDTOs.UserRoles;

namespace HaadCRM.Service.Services.UserRoles
{
    /// <summary>
    /// Interface defining operations related to user roles.
    /// </summary>
    public interface IUserRoleService
    {
        /// <summary>
        /// Creates a new user role based on the provided createModel.
        /// </summary>
        /// <param name="createModel">The model containing data for creating the user role.</param>
        /// <returns>The newly created user role view model.</returns>
        ValueTask<UserRoleViewModel> CreateAsync(UserRoleCreateModel createModel);

        /// <summary>
        /// Deletes a user role with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the user role to delete.</param>
        /// <returns>True if the deletion was successful; otherwise, false.</returns>
        ValueTask<bool> DeleteAsync(long id);

        /// <summary>
        /// Retrieves all user roles.
        /// </summary>
        /// <returns>An enumerable collection of user role view models.</returns>
        ValueTask<IEnumerable<UserRoleViewModel>> GetAllAsync();

        /// <summary>
        /// Retrieves a user role by its ID.
        /// </summary>
        /// <param name="id">The ID of the user role to retrieve.</param>
        /// <returns>The user role view model corresponding to the specified ID.</returns>
        ValueTask<UserRoleViewModel> GetByIdAsync(long id);

        /// <summary>
        /// Updates an existing user role with the specified ID using the provided updateModel.
        /// </summary>
        /// <param name="id">The ID of the user role to update.</param>
        /// <param name="updateModel">The model containing updated data for the user role.</param>
        /// <returns>The updated user role view model.</returns>
        ValueTask<UserRoleViewModel> UpdateAsync(long id, UserRoleUpdateModel updateModel);
    }
}
