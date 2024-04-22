using HaadCRM.Domain.Entities.Users;
using HaadCRM.Service.DTOs.UserDTOs.Users;

namespace HaadCRM.Service.Services.Users
{
    public interface IUserService
    {
        ValueTask<User> ChangePasswordAsync(string phone, string oldPassword, string newPassword);
        ValueTask<bool> ConfirmCodeAsync(string phone, string code);
        ValueTask<UserViewModel> CreateAsync(UserCreateModel createModel);
        ValueTask<bool> DeleteAsync(long id);
        ValueTask<IEnumerable<UserViewModel>> GetAllAsync();
        ValueTask<UserViewModel> GetByIdAsync(long id);
        ValueTask<(User user, string token)> LoginAsync(string phone, string password);
        ValueTask<bool> ResetPasswordAsync(string phone, string newPassword);
        ValueTask<bool> SendCodeAsync(string phone);
        ValueTask<UserViewModel> UpdateAsync(long id, UserUpdateModel updateModel);
    }
}