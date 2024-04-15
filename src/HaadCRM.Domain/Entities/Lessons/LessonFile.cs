using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities.Lessons;

public class LessonFile : Auditable
{
    public long LessonId { get; set; }
    public Lesson Lesson { get; set; }
    public string FilePath { get; set; }
}
