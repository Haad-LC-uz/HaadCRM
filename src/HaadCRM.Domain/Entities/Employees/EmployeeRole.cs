using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities.Employees;

/// <summary>
/// The EmployeeRole class represents the Employee role than contains properties for role, 
/// such as:
/// Name
/// </summary>
public class EmployeeRole : Auditable
{
    /// <summary>
    /// The Name property represents the name of the EmployeeRole
    /// </summary>
    public string Name { get; set; }
}