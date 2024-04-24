using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Domain.Entities.Students;

namespace HaadCRM.Domain.Entities.Homeworks;

/// <summary>
/// The HomeworkGrade class represents the HomeworkGrade entity that contains properties for HomeworkGrade,
/// such as:
/// StudentId
/// AssignmentId
/// HomeWorkId
/// Grade
/// HomeWork
/// Assistant
/// Student
/// </summary>
public class HomeworkGrade : Auditable
{
    /// <summary>
    /// The StudentId property represents the Id of the Student
    /// </summary>
    public long StudentId { get; set; }
    /// <summary>
    /// The AssistantId property represents the If of the Assistant
    /// </summary>
    public long AssistantId { get; set; }
    /// <summary>
    /// The HomeworkId property represents the ID of the Homework
    /// </summary>
    public long HomeworkId { get; set; }
    /// <summary>
    /// The Grade property represents the Student's grade to his homework
    /// </summary>
    public int Grade { get; set; }

    /// <summary>
    /// The Homework property represents the Homework object
    /// </summary>
    public Homework Homework { get; set; }
    /// <summary>
    /// The Assistant property represents the Assistant object
    /// </summary>
    public Employee Assistant { get; set; }
    /// <summary>
    /// The Student property represents the Student object
    /// </summary>
    public Student Student { get; set; }
}
