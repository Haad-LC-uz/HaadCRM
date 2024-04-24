using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Lessons;
using HaadCRM.Domain.Entities.Students;

namespace HaadCRM.Domain.Entities.Attendances;

/// <summary>
/// The Attendance class represents Attendance object that contains properties for student's attendance,
/// such as 
/// StudentId
/// LessonId
/// IsAttended
/// Student
/// Lesson
/// </summary>
public class Attendance : Auditable
{
    /// <summary>
    /// The StudentId property represents the Id of Student
    /// </summary>
    public long StudentId { get; set; }
    /// <summary>
    /// The LessonId Property represent the Id of Lesson
    /// </summary>
    public long LessonId { get; set; }
    /// <summary>
    /// The IsAttended property represents the status of Attendance
    /// </summary>
    public bool IsAttended { get; set; }

    /// <summary>
    /// The Student property represents the Student object
    /// </summary>
    public Student Student { get; set; }
    /// <summary>
    /// The Lesson property represents the Lesson object
    /// </summary>
    public Lesson Lesson { get; set; }
}
