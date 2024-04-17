using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Domain.Entities.Students;

namespace HaadCRM.Domain.Entities.Exams;

public class ExamGrade : Auditable
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
