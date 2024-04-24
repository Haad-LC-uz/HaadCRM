using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Groups;

namespace HaadCRM.Domain.Entities.Courses;

/// <summary>
/// The Couse class represents a Course that contains properties for course,
/// such as:
/// Name
/// Description
/// Groups
/// </summary>
public class Course : Auditable
{
    /// <summary>
    /// The Name property represents the name of the Course
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// The Description property represents the description of the Course
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// The Groups property represents the list of Groups that course Contains
    /// </summary>
    public IEnumerable<Group> Groups { get; set; }
}