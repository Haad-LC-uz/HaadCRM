using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Lessons;
using HaadCRM.Domain.Entities.Students;

namespace HaadCRM.Domain.Entities.Attendances;

public class Attendance : Auditable
{
    public long StudentId { get; set; }
    public long LessonId { get; set; }
    public bool IsAttended { get; set; }

    public Student Student { get; set; }
    public Lesson Lesson { get; set; }
}
