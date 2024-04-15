using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Groups;

namespace HaadCRM.Domain.Entities.Courses;

public class Course : Auditable
{
    public string Name { get; set; }
    public string Description { get; set; }

    public IEnumerable<Group> Groups { get; set; }
}