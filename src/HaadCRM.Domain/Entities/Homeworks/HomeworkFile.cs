using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities.Homeworks;

public class HomeworkFile : Auditable
{
    public long HomeworkId { get; set; }
    public long AssetId { get; set; }

    public Homework Homework { get; set; }
    public Asset Asset { get; set; }
}
