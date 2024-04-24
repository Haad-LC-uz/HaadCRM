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
    public long UserId { get; set; }
    public long PermissionId { get; set; }

    public User User { get; set; }
    public Permission Permission { get; set; }
}