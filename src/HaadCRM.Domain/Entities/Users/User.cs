using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Domain.Entities.Groups;
using HaadCRM.Domain.Entities.Students;

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
    /// <summary>
    /// The FirstName property represents the firstname of the user
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// The LastName property represents the lastname of the user
    /// </summary>
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    /// <summary>
    /// The Phone property represents the phone of the user
    /// </summary>
    public string Phone { get; set; }
    /// <summary>
    /// The UserRoleId property represents the Id of the UserRole
    /// </summary>
    public long UserRoleId { get; set; }

    /// <summary>
    /// The UserRole property represents the UserRole object
    /// </summary>
    public UserRole UserRole { get; set; }
}
