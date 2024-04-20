using HaadCRM.Service.DTOs.UserDTOs.Users;

namespace HaadCRM.Service.Services.Users
{
    /// <summary>
    /// Interface defining operations related to users.
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Creates a new user based on the provided createModel.
        /// </summary>
        /// <param name="createModel">The model containing data for creating the user.</param>
        /// <returns>The newly created user view model.</returns>
        ValueTask<UserViewModel> CreateAsync(UserCreateModel createModel);

        /// <summary>
        /// Deletes a user with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>True if the deletion was successful; otherwise, false.</returns>
        ValueTask<bool> DeleteAsync(long id);

        /// <summary>
        /// Retrieves all users.
        /// </summary>
        /// <returns>An enumerable collection of user view models.</returns>
        ValueTask<IEnumerable<UserViewModel>> GetAllAsync();

        /// <summary>
        /// Retrieves a user by its ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>The user view model corresponding to the specified ID.</returns>
        ValueTask<UserViewModel> GetByIdAsync(long id);

        /// <summary>
        /// Updates an existing user with the specified ID using the provided updateModel.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="updateModel">The model containing updated data for the user.</param>
        /// <returns>The updated user view model.</returns>
        ValueTask<UserViewModel> UpdateAsync(long id, UserUpdateModel updateModel);
    }
}
