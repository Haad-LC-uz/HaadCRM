using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Domain.Entities.Groups;

namespace HaadCRM.Domain.Entities.Exams;

public class Exam : Auditable
{
    public long TeacherId { get; set; }
    public long AssistantId { get; set; }
    public long GroupId { get; set; }
    public string PicturePath { get; set; }
    public DateTime DateOfExam { get; set; }
    public DateTime DeadLine { get; set; }

    public Employee Teacher { get; set; }
    public Employee Assistant { get; set; }
    public Group Group { get; set; }

    public IEnumerable<ExamFiles> ExamFiles { get; set; }
    public IEnumerable<ExamGrades> ExamGrades { get; set; }
}
