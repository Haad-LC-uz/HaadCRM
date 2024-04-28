using HaadCRM.Service.DTOs.GroupDTOs.Groups;
using HaadCRM.Service.DTOs.StudentDTOs.Students;

namespace HaadCRM.Service.DTOs.GroupDTOs.GroupStudents;

public class GroupStudentViewModel
{
    public bool IsPaid { get; set; }
    public bool IsPassed { get; set; }
    public GroupViewModel Group { get; set; }
    public StudentViewModel Student { get; set; }
}
