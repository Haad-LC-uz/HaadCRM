using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities.Lessons;

/// <summary>
/// The LessonFile class represents the LessonFile entity that contains proprerties for LessonFile,
/// such as:
/// LessonId
/// AssetId
/// Lesson
/// Asset
/// </summary>
public class LessonFile : Auditable
{
    public long LessonId { get; set; }
    public long AssetId { get; set; }

    public Lesson Lesson { get; set; }
    public Asset Asset { get; set; }
}
