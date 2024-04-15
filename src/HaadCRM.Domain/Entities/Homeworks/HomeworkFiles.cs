using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities.Homeworks;

public class HomeworkFiles : Auditable
{
    public long HomeworkId { get; set; }
    public string FilePath { get; set; }

    public Homework Homework { get; set; }
}
