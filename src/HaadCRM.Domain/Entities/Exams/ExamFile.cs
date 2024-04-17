using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities.Exams;

public class ExamFile : Auditable
{
    public long ExamId { get; set; }
    public long AssetId { get; set; }

    public Exam Exam { get; set; }
    public Asset Asset { get; set; }
}