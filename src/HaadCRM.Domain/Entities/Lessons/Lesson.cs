using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Groups;

namespace HaadCRM.Domain.Entities.Lessons;

public class Lesson : Auditable
{
    public long GroupId { get; set; }
    public DateTime DateOfLesson { get; set; }
    public string Name { get; set; }

    public Group Group { get; set; }

    public IEnumerable<LessonFile> Files { get; set; }
}