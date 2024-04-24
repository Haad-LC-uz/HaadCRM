using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Groups;

namespace HaadCRM.Domain.Entities.Students;

/// <summary>
/// The RemovedStudent class represents the RemovedStudent entity that contains properties for RemovedStudent,
/// such as:
/// StudentId
/// GroupId
/// Reason
/// Group
/// Student
/// </summary>
public class RemovedStudent : Auditable
{
    /// <summary>
    /// The StudentId property represents the Id of the Student
    /// </summary>
    public long StudentId { get; set; }
    /// <summary>
    /// The GroupId property represents the Id of the Group
    /// </summary>
    public long GroupId { get; set; }
    /// <summary>
    /// The Reason property represents the reason that why Students was removed
    /// </summary>
    public string Reason { get; set; }

    /// <summary>
    /// The Group property represents the Group object
    /// </summary>
    public Group Group { get; set; }
    /// <summary>
    /// The Student property represents the Student object
    /// </summary>
    public Student Student { get; set; }
}
