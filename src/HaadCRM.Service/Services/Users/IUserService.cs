using HaadCRM.Service.DTOs.UserDTOs.Users;

namespace HaadCRM.Service.Services.Users;

public interface IUserService
{
    ValueTask<UserViewModel> CreateAsync(UserCreateModel createModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<UserViewModel>> GetAllAsync();
    ValueTask<UserViewModel> GetByIdAsync(long id);
    ValueTask<UserViewModel> UpdateAsync(long id, UserUpdateModel updateModel);
}