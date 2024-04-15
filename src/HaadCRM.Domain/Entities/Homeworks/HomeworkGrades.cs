using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities.Homeworks;

public class HomeworkGrades : Auditable
{
    public long StudentId { get; set; }
    public long AssistantId { get; set; }
    public long HomeworkId { get; set; }
    public int Grade { get; set; }

    public Homework Homework { get; set; }
    public Employee Assistant { get; set; }
    public Student Student { get; set; }
}
