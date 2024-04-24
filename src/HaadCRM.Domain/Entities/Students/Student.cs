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
    /// <summary>
    /// The UserId property represents the Id of the User
    /// </summary>
    public long UserId { get; set; }
    /// <summary>
    /// The AssetId property represents the Id of the Asset
    /// </summary>
    public long AssetId { get; set; }

    /// <summary>
    /// The User property represents the User object
    /// </summary>
    public User User { get; set; }
    /// <summary>
    /// The Asset property represents the Asset object
    /// </summary>
    public Asset Asset { get; set; }

    /// <summary>
    /// The Attendances property represents the list of Attendance that Student has
    /// </summary>
    public IEnumerable<Attendance> Attendances { get; set; }
}
