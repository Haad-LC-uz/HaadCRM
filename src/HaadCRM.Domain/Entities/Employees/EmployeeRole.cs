using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities.Employees;

public class EmployeeRole : Auditable
{
    public string Name { get; set; }
}