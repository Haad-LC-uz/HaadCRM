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
    /// <summary>
    /// the LessonId property represents the Id of the Lesson
    /// </summary>
    public long LessonId { get; set; }
    /// <summary>
    /// The AssistantId property represents the If of Assistant
    /// </summary>
    public long AssistantId { get; set; }
    /// <summary>
    /// The Title property represents the Title of the Homework
    /// </summary>
    public string Title { get; set; }
    /// <summary>
    /// The Description property represents the Description of the Homework
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// The DeadLine property represents the deadline for homework
    /// </summary>
    public DateTime DeadLine { get; set; }

    /// <summary>
    /// The Lesson property represents the Lesson object
    /// </summary>
    public Lesson Lesson { get; set; }
    /// <summary>
    /// The Assistant property represents the Assistant object
    /// </summary>
    public Employee Assistant { get; set; }
    /// <summary>
    /// The HomeworkFiles property represents the list of HomeworkFiles that Homework has       
    /// </summary>
    public IEnumerable<HomeworkFile> HomeworkFiles { get; set; }
    /// <summary>
    /// The HomeworkGrades property represents the list of HomeworkGrades that Homework has       
    /// </summary>
    public IEnumerable<HomeworkGrade> HomeworkGrades { get; set; }
}
