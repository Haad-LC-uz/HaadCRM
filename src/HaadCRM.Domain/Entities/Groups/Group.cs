using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Courses;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Domain.Entities.Lessons;
using HaadCRM.Domain.Entities.Students;

namespace HaadCRM.Domain.Entities.Groups;

/// <summary>
/// The Group class represents the Group entity that contains properties for Group,
/// such as:
/// Course
/// Teacher
/// Name
/// StartTime
/// Duration
/// EndTime
/// Price
/// Room
/// Course
/// Teacher
/// Assistant
/// Lessons
/// GroupStudents
/// RemovedStudents
/// </summary>
public class Group : Auditable
{
    /// <summary>
    /// The CourseId property represents the Id of the Course
    /// </summary>
    public long CourseId { get; set; }
    /// <summary>
    /// The TeacherId property represents the Id of the Teacher
    /// </summary>
    public long TeacherId { get; set; }
    /// <summary>
    /// The AssistantId property represents the Id of the Assistant
    /// </summary>
    public long AssistantId { get; set; }
    /// <summary>
    /// The Name property represents the Name of the Group
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// The StartTime property represents the lesson's start time in this group
    /// </summary>
    public DateTime StartTime { get; set; }
    /// <summary>
    /// The Duration property represents the lesson's duration in this group
    /// </summary>
    public int Duration { get; set; }
    /// <summary>
    /// The EndTime property represents the lesson's end time in this group
    /// </summary>
    public DateTime EndTime { get; set; }
    /// <summary>
    /// The Price property represents the price for student to studying in this group
    /// </summary>
    public decimal Price { get; set; }
    /// <summary>
    /// The Room property represents the Room of this group in Learning Centre
    /// </summary>
    public string Room { get; set; }

    /// <summary>
    /// The Course property represents the Course object
    /// </summary>
    public Course Course { get; set; }
    /// <summary>
    /// The Teacher property represents the Teacher object
    /// </summary>
    public Employee Teacher { get; set; }
    /// <summary>
    /// The Assistant property represents the Assistant object
    /// </summary>
    public Employee Assistant { get; set; }

    /// <summary>
    /// The Lessons property represents the list of Lessons that Group has
    /// </summary>
    public IEnumerable<Lesson> Lessons { get; set; }
    /// <summary>
    /// The GroupStudents property represents the list of GroupStudents that Group has
    /// </summary>
    public IEnumerable<GroupStudent> GroupStudents { get; set; }
    /// <summary>
    /// The RemovedStudents property represents the list of RemovedStudents that Group has
    /// </summary>
    public IEnumerable<RemovedStudent> RemovedStudents { get; set; }
}