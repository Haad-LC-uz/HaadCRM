using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Groups;

namespace HaadCRM.Domain.Entities.Lessons;

/// <summary>
/// The Lesson class represents the Lesson entity that contains properties for Lesson, 
/// such as:
/// GroupId
/// DateOfLesson
/// Name
/// Group
/// Files
/// </summary>
public class Lesson : Auditable
{

    public long GroupId { get; set; }
    public DateTime DateOfLesson { get; set; }
    public string Name { get; set; }

    public Group Group { get; set; }

    public IEnumerable<LessonFile> Files { get; set; }
}