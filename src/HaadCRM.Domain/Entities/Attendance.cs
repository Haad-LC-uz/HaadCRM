using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities;

public class Attendance : Auditable
{
    public long StudentId { get; set; }
    public Student Student { get; set; }
    public long LessonId { get; set; }
    public Lesson Lesson { get; set; }
    public bool IsAttended { get; set; }


}
