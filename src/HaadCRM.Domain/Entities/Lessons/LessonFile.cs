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
    /// <summary>
    /// The LessonId property represents the Id of the Lesson
    /// </summary>
    public long LessonId { get; set; }
    /// <summary>
    /// The AssetId property represents the Id of the Asset
    /// </summary>
    public long AssetId { get; set; }

    /// <summary>
    /// The Lesson property represents the Lesson object
    /// </summary>
    public Lesson Lesson { get; set; }
    /// <summary>
    /// The Asset property represents the Asset object
    /// </summary>
    public Asset Asset { get; set; }
}
