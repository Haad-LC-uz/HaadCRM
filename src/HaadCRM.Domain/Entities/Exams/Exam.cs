using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Domain.Entities.Groups;

namespace HaadCRM.Domain.Entities.Exams;

/// <summary>
/// The Exam class represents the Exam that contains properties for Exam,
/// such as:
/// TeacherId
/// AssistantId
/// GroupId
/// AssetId
/// DateOfExam
/// DeadLine
/// Teacher
/// Assistant
/// Group
/// ProfilePicture
/// ExamFiles
/// ExamGrades
/// </summary>
public class Exam : Auditable
{
    /// <summary>
    /// The TeacherId property represents the Id of the Teacher
    /// </summary>
    public long TeacherId { get; set; }
    /// <summary>
    /// The AssistantId property represents the Id of the Assistant
    /// </summary>
    public long AssistantId { get; set; }
    /// <summary>
    /// The GroupId property represents the Id of the Group
    /// </summary>
    public long GroupId { get; set; }
    /// <summary>
    /// The AssetId property represents the Id of the Asset
    /// </summary>
    public long AssetId { get; set; }
    /// <summary>
    /// The DateOfExam property represents the Date of the Exam
    /// </summary>
    public DateTime DateOfExam { get; set; }
    /// <summary>
    /// The DeadLine property represents the Deadline for the Exam
    /// </summary>
    public DateTime DeadLine { get; set; }

    /// <summary>
    /// The Teacher property represents the Teacher object
    /// </summary>
    public Employee Teacher { get; set; }
    /// <summary>
    /// The Assistant property represents the Assistant object
    /// </summary>
    public Employee Assistant { get; set; }
    /// <summary>
    /// The Group represents the Group object
    /// </summary>
    public Group Group { get; set; }
    /// <summary>
    /// The ProfilePicture property represents the ProfilePicture object
    /// </summary>
    public Asset ProfilePicture { get; set; }

    /// <summary>
    /// The ExamFiles property represents the list of Exam files that Exam has
    /// </summary>
    public IEnumerable<ExamFile> ExamFiles { get; set; }
    /// <summary>
    /// The ExamGrades property represents the list of Grades that Exam has
    /// </summary>
    public IEnumerable<ExamGrade> ExamGrades { get; set; }
}
