using HaadCRM.Domain.Entities.Users; // Namespace containing User entity definition
using HaadCRM.Service.DTOs.UserDTOs.Users; // Namespace containing User DTOs (Data Transfer Objects)

namespace HaadCRM.Service.Services.Users;

public interface IUserService
{
    /// <summary>
    /// Changes a user's password.
    /// </summary>
    /// <param name="phone">The user's phone number.</param>
    /// <param name="oldPassword">The user's current password.</param>
    /// <param name="newPassword">The user's desired new password.</param>
    /// <returns>A task containing the updated User object if successful.</returns>
    ValueTask<User> ChangePasswordAsync(string phone, string oldPassword, string newPassword);

    /// <summary>
    /// Confirms a verification code sent to the user's phone number.
    /// </summary>
    /// <param name="phone">The user's phone number.</param>
    /// <param name="code">The verification code sent to the user's phone.</param>
    /// <returns>A task containing a boolean indicating if the code was confirmed successfully.</returns>
    ValueTask<bool> ConfirmCodeAsync(string phone, string code);

    /// <summary>
    /// Creates a new user account.
    /// </summary>
    /// <param name="createModel">A UserCreateModel object containing data for the new user.</param>
    /// <returns>A task containing a UserViewModel object representing the created user.</returns>
    ValueTask<UserViewModel> CreateAsync(UserCreateModel createModel);

    /// <summary>
    /// Deletes a user account by its ID.
    /// </summary>  
    /// <param name="id">The unique identifier of the user account to be deleted.</param>
    /// <returns>A task containing a boolean indicating if the deletion was successful.</returns>  
    ValueTask<bool> DeleteAsync(long id);

    /// <summary>
    /// Retrieves all user accounts as UserViewModel objects.
    /// </summary>
    /// <returns>A task containing an IEnumerable collection of UserViewModel objects.</returns>
    ValueTask<IEnumerable<UserViewModel>> GetAllAsync();

    /// <summary>
    /// Gets a user account by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the user account to be retrieved.</param>
    /// <returns>A task containing a UserViewModel object representing the retrieved user.</returns>
    ValueTask<UserViewModel> GetByIdAsync(long id);

    /// <summary>
    /// Logs a user in using their phone number and password.
    /// </summary>
    /// <param name="phone">The user's phone number.</param>
    /// <param name="password">The user's password.</param>
    /// <returns>A task containing a tuple with the User object and a token if login is successful, 
    /// otherwise null and an empty string.</returns>
    ValueTask<(User user, string token)> LoginAsync(string phone, string password);

    /// <summary>
    /// Resets a user's password without requiring the old password.
    /// </summary>
    /// <param name="phone">The user's phone number.</param>
    /// <param name="newPassword">The user's desired new password.</param>
    /// <returns>A task containing a boolean indicating if the password reset was successful.</returns>
    ValueTask<bool> ResetPasswordAsync(string phone, string newPassword);

    /// <summary>
    /// Sends a verification code to the user's phone number.
    /// </summary>
    /// <param name="phone">The phone number to send the verification code to.</param>
    /// <returns>A task containing a boolean indicating if the code was sent successfully.</returns>
    ValueTask<bool> SendCodeAsync(string phone);

    /// <summary>
    /// Updates an existing user account.
    /// </summary>
    /// <param name="id">The unique identifier of the user account to be updated.</param>
    /// <param name="updateModel">A UserUpdateModel object containing data for the update.</param>
    /// <returns>A task containing a UserViewModel object representing the updated user.</returns>
    ValueTask<UserViewModel> UpdateAsync(long id, UserUpdateModel updateModel);
}
