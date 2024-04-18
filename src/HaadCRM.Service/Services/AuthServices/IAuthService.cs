using HaadCRM.Domain.Entities.Users;

namespace HaadCRM.Service.Services.AuthServices;

public interface IAuthService
{
    string GenerateToken(User user);
}