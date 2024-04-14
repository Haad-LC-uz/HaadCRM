using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities;

public class Group : Auditable
{
    public Course Course { get; set; }
    public Employee TeacherId { get; set; }
    public Employee AssistantId { get; set; }
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public int Duration { get; set; }
    public DateTime EndTime { get; set; }
    public decimal Price { get; set; }
    public string Room { get; set; }
}