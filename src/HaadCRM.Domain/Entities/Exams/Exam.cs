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
    public long TeacherId { get; set; }
    public long AssistantId { get; set; }
    public long GroupId { get; set; }
    public long AssetId { get; set; }
    public DateTime DateOfExam { get; set; }
    public DateTime DeadLine { get; set; }
    public Employee Teacher { get; set; }
    public Employee Assistant { get; set; }
    public Group Group { get; set; }
    public Asset ProfilePicture { get; set; }
}
