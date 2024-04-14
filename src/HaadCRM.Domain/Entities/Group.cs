using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities;

public class Group : Auditable
{
    public long CourseId { get; set; }
    public Course Course { get; set; }
    public long TeacherId { get; set; }
    public Employee Teacher { get; set; }
    public long AssistantId { get; set; }
    public Employee Assistant { get; set; }
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public int Duration { get; set; }
    public DateTime EndTime { get; set; }
    public decimal Price { get; set; }
    public string Room { get; set; }

    public IEnumerable<Lesson> Lessons { get; set; }
}