using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Attendances;
using HaadCRM.Domain.Entities.Users;

namespace HaadCRM.Domain.Entities.Students;

/// <summary>
/// The Student class represents the Student entity that contains properties for Student, 
/// such as 
/// UserId
/// AssetId
/// User
/// Asset
/// </summary>
public class Student : Auditable
{
    public long UserId { get; set; }
    public long AssetId { get; set; }

    public User User { get; set; }
    public Asset Asset { get; set; }

    public IEnumerable<Attendance> Attendances { get; set; }
}
