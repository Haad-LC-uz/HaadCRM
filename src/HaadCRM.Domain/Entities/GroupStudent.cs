using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities;

public class GroupStudent : Auditable
{
    public long GroupId { get; set; }
    public Group Group { get; set; }
    public long StudentId { get; set; }
    public Student Student { get; set; }
    public bool IsPaid { get; set; }
    public bool IsPassed { get; set; }
}
