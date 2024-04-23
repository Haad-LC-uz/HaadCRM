using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities.Homeworks;

/// <summary>
/// The HomeworkFile class represents the HomeworkFile entity that contains properties for HomeworkFile,
/// such as:
/// HomeworkId
/// AssetId
/// </summary>
public class HomeworkFile : Auditable
{
    public long HomeworkId { get; set; }
    public long AssetId { get; set; }

    public Homework Homework { get; set; }
    public Asset Asset { get; set; }
}
