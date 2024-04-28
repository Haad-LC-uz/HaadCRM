using HaadCRM.Domain.Entities.Groups;
using HaadCRM.Domain.Entities.Students;

namespace HaadCRM.Service.DTOs.StudentDTOs.RemovedStudents;

public class RemovedStudentViewModel
{
    public string Reason { get; set; }
    public Student Student { get; set; }
    public Group Group { get; set; }
}
