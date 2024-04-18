using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Students;

namespace HaadCRM.Domain.Entities.Groups;

public class GroupStudent : Auditable
{
    public long GroupId { get; set; }
    public long StudentId { get; set; }
    public bool IsPaid { get; set; }
    public bool IsPassed { get; set; }

    public Group Group { get; set; }
    public Student Student { get; set; }
}
