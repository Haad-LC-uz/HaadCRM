using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Courses;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Domain.Entities.Lessons;
using HaadCRM.Domain.Entities.Students;

namespace HaadCRM.Domain.Entities.Groups;

/// <summary>
/// The Group class represents the Group entity that contains properties for Group,
/// such as:
/// Course,
/// Teacher,
/// Name
/// StartTime
/// Duration
/// EndTime
/// Price
/// Room
/// </summary>
public class Group : Auditable
{
    public long CourseId { get; set; }
    public long TeacherId { get; set; }
    public long AssistantId { get; set; }
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public int Duration { get; set; }
    public DateTime EndTime { get; set; }
    public decimal Price { get; set; }
    public string Room { get; set; }

    public Course Course { get; set; }
    public Employee Teacher { get; set; }
    public Employee Assistant { get; set; }

    public IEnumerable<Lesson> Lessons { get; set; }
    public IEnumerable<GroupStudent> GroupStudents { get; set; }
    public IEnumerable<RemovedStudent> RemovedStudents { get; set; }
}