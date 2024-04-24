using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities.Homeworks;

/// <summary>
/// The HomeworkFile class represents the HomeworkFile entity that contains properties for HomeworkFile,
/// such as:
/// HomeworkId
/// AssetId
/// Homework
/// Assistant
/// </summary>
public class HomeworkFile : Auditable
{
    /// <summary>
    /// The HomeworkId property represents the Id of the Homework
    /// </summary>
    public long HomeworkId { get; set; }
    /// <summary>
    /// The AssetId property represents the Id of the Asset
    /// </summary>
    public long AssetId { get; set; }

    /// <summary>
    /// The Homework property represents the Homework object
    /// </summary>
    public Homework Homework { get; set; }
    /// <summary>
    /// The Asset property represents the Asset object
    /// </summary>
    public Asset Asset { get; set; }
}
