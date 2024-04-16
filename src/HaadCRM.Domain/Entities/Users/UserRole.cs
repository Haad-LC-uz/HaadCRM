using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities.Users;

public class UserRole : Auditable
{
    public string Name { get; set; }
}