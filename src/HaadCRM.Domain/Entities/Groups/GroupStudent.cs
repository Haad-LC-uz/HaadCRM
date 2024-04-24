using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Students;

namespace HaadCRM.Domain.Entities.Groups;

/// <summary>
/// The GroupStudent class represents the GroupStudent entity that contains properties for GroupStudent,
/// such as: 
/// GroupId
/// StudentId
/// IsPaid
/// IsPassed
/// Group
/// Student
/// </summary>
public class GroupStudent : Auditable
{
    /// <summary>
    /// The GroupId property represents the Id of the Group
    /// </summary>
    public long GroupId { get; set; }
    /// <summary>
    /// The StudentId property represents the Id of the Student
    /// </summary>
    public long StudentId { get; set; }
    /// <summary>
    /// The IsPaid property represents the status of Student's payment for course 
    /// </summary>
    public bool IsPaid { get; set; }
    /// <summary>
    /// The IsPassed property represents the status of Student's exam pass from exam
    /// </summary>
    public bool IsPassed { get; set; }

    /// <summary>
    /// The Group property reprents the Group object
    /// </summary>
    public Group Group { get; set; }
    /// <summary>
    /// The Student property represents the Student object
    /// </summary>
    public Student Student { get; set; }
}
