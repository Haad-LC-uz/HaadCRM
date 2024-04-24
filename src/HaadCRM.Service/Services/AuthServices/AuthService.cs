using HaadCRM.Domain.Entities.Users;
using HaadCRM.Service.Services.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HaadCRM.Service.Services.AuthServices;

public class AuthService(IOptions<JwtOption> options) : IAuthService
{
    private readonly JwtOption jwtOption = options.Value;
    public string GenerateToken(User user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(jwtOption.Key);
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Audience = jwtOption.Audience,
            Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(jwtOption.LifeTime)),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature),
            Issuer = jwtOption.Issuer,
            Subject = new ClaimsIdentity(new Claim[]
            {
                new("Id", user.Id.ToString()),
                new("Phone", user.Phone),
                new(ClaimTypes.Role, user.UserRole.Name)
            })
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}

