using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities.Users;


public class Permission : Auditable
{
    /// <summary>
    /// The Method property represents what method is target of the permission
    /// </summary>
    public string Method { get; set; }
    /// <summary>
    /// The Contoller property represents what Type of user is target of the permission
    /// </summary>
    public string Controller { get; set; }
}