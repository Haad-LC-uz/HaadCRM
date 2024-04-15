using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities.Exams;

public class ExamFiles : Auditable
{
    public long ExamId { get; set; }
    public string FilePath { get; set; }

    public Exam Exam { get; set; }
}