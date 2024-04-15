using HaadCRM.Domain.Commons;

namespace HaadCRM.Domain.Entities;

public class Course : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }

    public IEnumerable<Group> Groups { get; set; }
}