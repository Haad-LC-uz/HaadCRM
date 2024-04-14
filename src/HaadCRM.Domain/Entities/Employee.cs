using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Enums;

namespace HaadCRM.Domain.Entities;

public class Employee : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Description { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public decimal Salary { get; set; }
    public string PicturePath { get; set; }
    public Role Role { get; set; }
}