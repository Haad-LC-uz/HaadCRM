using HaadCRM.Domain.Entities.Groups;
using HaadCRM.Domain.Entities.Students;

namespace HaadCRM.Service.DTOs.GroupStudents;

public class GroupStudentViewModel
{
    public long Id { get; set; }
    public Group Group { get; set; }
    public Student Student { get; set; }
    public bool IsPaid { get; set; }
    public bool IsPassed { get; set; }
}
