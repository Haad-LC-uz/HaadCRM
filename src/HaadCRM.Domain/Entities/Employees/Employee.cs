using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Groups;
using HaadCRM.Domain.Entities.Users;

namespace HaadCRM.Domain.Entities.Employees;

/// <summary>
/// The Employee class represents an Employee that contains properties for Employee,
/// such as:
/// UserId
/// EmployeeRoleId
/// AssetId
/// Description
/// Salary
/// User
/// EmployeeRole
/// Asset
/// Groups
/// </summary>
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
}