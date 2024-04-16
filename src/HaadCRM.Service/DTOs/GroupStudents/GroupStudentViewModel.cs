using HaadCRM.Domain.Entities.Students;
using System.Text.RegularExpressions;

namespace HaadCRM.Service.DTOs.GroupStudents;

public class GroupStudentViewModel
{
    public Group Group { get; set; }
    public Student Student { get; set; }
    public bool IsPaid { get; set; }
    public bool IsPassed { get; set; }
}
