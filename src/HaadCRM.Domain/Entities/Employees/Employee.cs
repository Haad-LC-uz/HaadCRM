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
    /// <summary>
    /// The UserId property represents the Id of the User
    /// </summary>
    public long UserId { get; set; }
    /// <summary>
    /// The EmployeeRoleId property represents the Id of EmployeeRole
    /// </summary>
    public long EmployeeRoleId { get; set; }
    /// <summary>
    /// The AssetId property represents the Id of Asset that Employee has
    /// </summary>
    public long AssetId { get; set; }
    /// <summary>
    /// The Desctiption property represents the Description about Employee
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// The Salary Property Represents the Salary of the Employee
    /// </summary>
    public decimal Salary { get; set; }

    /// <summary>
    /// The User property represents the User object
    /// </summary>
    public User User { get; set; }
    /// <summary>
    /// The EmployeeRole property represents the EmployeeRole object
    /// </summary>
    public EmployeeRole EmployeeRole { get; set; }
    /// <summary>
    /// The Asset property represents the Asset object
    /// </summary>
    public Asset Asset { get; set; }
}