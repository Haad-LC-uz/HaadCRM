using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Users;
using HaadCRM.Domain.Entities.Groups;

namespace HaadCRM.Domain.Entities.Employees;

public class Employee : Auditable
{
    public long UserId { get; set; }
    public long EmployeeRoleId { get; set; }
    public long AssetId { get; set; }
    public string Description { get; set; }
    public decimal Salary { get; set; }

    public User User { get; set; }
    public EmployeeRole EmployeeRole { get; set; }
    public Asset Asset { get; set; }

    public IEnumerable<Group> Groups { get; set; }
}