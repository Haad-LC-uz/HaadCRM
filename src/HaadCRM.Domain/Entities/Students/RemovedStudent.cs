using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Groups;

namespace HaadCRM.Domain.Entities.Students;

public class RemovedStudent : Auditable
{
    public long StudentId { get; set; }
    public long GroupId { get; set; }
    public string Reason { get; set; }

    public Group Group { get; set; }
    public Student Student { get; set; }
}
