using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Courses;
using HaadCRM.Domain.Entities.Lessons;
using HaadCRM.Domain.Entities.Students;
using HaadCRM.Domain.Entities.Employees;

namespace HaadCRM.Domain.Entities.Groups;

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