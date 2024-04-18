using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Students;
using HaadCRM.Domain.Entities.Employees;

namespace HaadCRM.Domain.Entities.Homeworks;

public class HomeworkGrade : Auditable
{
    public long StudentId { get; set; }
    public long AssistantId { get; set; }
    public long HomeworkId { get; set; }
    public int Grade { get; set; }

    public Homework Homework { get; set; }
    public Employee Assistant { get; set; }
    public Student Student { get; set; }
}
