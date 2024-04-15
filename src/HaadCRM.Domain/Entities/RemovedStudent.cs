using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities;

public class RemovedStudent : Auditable
{
    public long StudentId { get; set; }
    public Student Student { get; set; }
    public long GroupId { get; set; }
    public Group Group { get; set; }
    public string Reason { get; set; }
}
