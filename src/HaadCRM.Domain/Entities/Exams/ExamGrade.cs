using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Domain.Entities.Students;

namespace HaadCRM.Domain.Entities.Exams;

/// <summary>
/// The ExamGrade class represents the student's grade from exam that contains properties for ExamGrade, 
/// such as StudentId, ExamId, TeacherId, AssistantId and Grade
/// </summary>
public class ExamGrade : Auditable
{
    /// <summary>
    /// The StudentId property represents the Id of the Student
    /// </summary>
    public long StudentId { get; set; }
    /// <summary>
    /// The ExamId property represents the Id of the Exam
    /// </summary>
    public long ExamId { get; set; }
    /// <summary>
    /// The TeacherId property represents the Id of the Teacher
    /// </summary>
    public long TeacherId { get; set; }
    /// <summary>
    /// The AssistantId property represents the Id of the Assistant
    /// </summary>
    public long AssistantId { get; set; }
    /// <summary>
    /// The Grade property represents the Grade of the student from exam
    /// </summary>
    public int Grade { get; set; }

    /// <summary>
    /// The Student property represents the Student object
    /// </summary>
    public Student Student { get; set; }
    /// <summary>
    /// The Exam property represents the Exam object
    /// </summary>
    public Exam Exam { get; set; }
    /// <summary>
    /// The Teacher property represents the Teacher object
    /// </summary>
    public Employee Teacher { get; set; }
    /// <summary>
    /// The Assistant property represents the Assistant object
    /// </summary>
    public Employee Assistant { get; set; }
}
