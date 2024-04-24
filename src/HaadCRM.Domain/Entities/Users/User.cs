using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities.Users;

/// <summary>
/// The User class represents the User entity that contains properties for User,
/// such as
/// FirstName
/// LastName
/// Email
/// Password
/// Phone
/// UserRoleId
/// UserRole
/// </summary>
public class User : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Phone { get; set; }
    public long UserRoleId { get; set; }

    public UserRole UserRole { get; set; }
}
