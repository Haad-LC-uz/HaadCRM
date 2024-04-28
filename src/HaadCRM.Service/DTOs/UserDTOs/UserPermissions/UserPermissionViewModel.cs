using HaadCRM.Domain.Entities.Users;

namespace HaadCRM.Service.DTOs.UserDTOs.UserPermissions;

public class UserPermissionViewModel
{
    public User User { get; set; }
    public Permission Permission { get; set; }
}