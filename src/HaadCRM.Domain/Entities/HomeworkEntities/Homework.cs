using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Domain.Entities.Lessons;

namespace HaadCRM.Domain.Entities.Homeworks;

/// <summary>
/// The Homework class represents the Homework entity that contains properties for Homework,
/// such as:
/// LessonId
/// AssistantId
/// Title
/// Description
/// DeadLine
/// HomeworkFiles
/// HomeworkGrades
/// </summary>
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
