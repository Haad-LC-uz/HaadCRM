using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Attendances;

namespace HaadCRM.Domain.Entities.Students;

public class Student : Auditable
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Password { get; set; }
    public string ProfilePicturePath { get; set; }

    public IEnumerable<Attendance> Attendances { get; set; }
}
