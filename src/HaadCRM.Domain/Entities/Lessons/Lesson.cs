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
    /// <summary>
    /// The GroupId property represents the Id of the Group
    /// </summary>
    public long GroupId { get; set; }
    /// <summary>
    /// The DateOfLesson property represents the Date of the Lesson
    /// </summary>
    public DateTime DateOfLesson { get; set; }
    /// <summary>
    /// The Name property represents the name of the Lesson
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// The Group property represents the Group object
    /// </summary>
    public Group Group { get; set; }

    /// <summary>
    /// The Files property represents the list of files that Lesson has
    /// </summary>
    public IEnumerable<LessonFile> Files { get; set; }
}