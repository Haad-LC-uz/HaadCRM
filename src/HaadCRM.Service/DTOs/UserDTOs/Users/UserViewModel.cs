using HaadCRM.Domain.Entities.Users;
using HaadCRM.Service.DTOs.UserDTOs.UserRoles;

namespace HaadCRM.Service.DTOs.UserDTOs.Users;

public class UserViewModel
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public UserRoleViewModel UserRole { get; set; }
}