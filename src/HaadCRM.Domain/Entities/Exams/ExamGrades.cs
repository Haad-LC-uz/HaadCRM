using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities.Exams;

public class ExamGrades : Auditable
{
    public long StudentId { get; set; }
    public long ExamId { get; set; }
    public long TeacherId { get; set; }
    public long AssistantId { get; set; }
    public int Grade { get; set; }

    public Student Student { get; set; }
    public Exam Exam { get; set; }
    public Employee Teacher { get; set; }
    public Employee Assistant { get; set; }
}
