using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Domain.Entities.Lessons;

namespace HaadCRM.Domain.Entities.Homeworks;

public class Homework : Auditable
{
    public long LessonId { get; set; }
    public long AssistantId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DeadLine { get; set; }

    public Lesson Lesson { get; set; }
    public Employee Assistant { get; set; }
    public IEnumerable<HomeworkFile> HomeworkFiles { get; set; }
    public IEnumerable<HomeworkGrade> HomeworkGrades { get; set; }
}
