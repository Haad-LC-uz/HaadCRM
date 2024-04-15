using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities;

public class Lesson : Auditable
{
    public long GroupId { get; set; }
    public Group Group { get; set; }
    public string Name { get; set; }
}