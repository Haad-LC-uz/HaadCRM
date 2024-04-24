using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities.Users;

/// <summary>
/// The UserPermission class represents the UserPermission entity that contains properties for UserPermission,
/// such as"
/// UserId
/// PermissionId
/// User
/// Permission
/// </summary>
public class UserPermission : Auditable
{
    /// <summary>
    /// The UserId property represents the Id of the User
    /// </summary>
    public long UserId { get; set; }
    /// <summary>
    /// The PermissionId property represents the Id of the Permission
    /// </summary>
    public long PermissionId { get; set; }

    /// <summary>
    /// The User property represents the User object
    /// </summary>
    public User User { get; set; }
    /// <summary>
    /// The Permission property represents the Persmission object
    /// </summary>
    public Permission Permission { get; set; }
}