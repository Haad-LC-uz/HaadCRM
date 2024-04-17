using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities.Users;

public class Permission : Auditable
{
    public string Method { get; set; }
    public string Controller { get; set; }
}