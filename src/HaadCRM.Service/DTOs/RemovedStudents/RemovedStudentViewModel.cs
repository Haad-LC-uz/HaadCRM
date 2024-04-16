using HaadCRM.Domain.Entities.Groups;
using HaadCRM.Domain.Entities.Students;

namespace HaadCRM.Service.DTOs.RemovedStudents;

public class RemovedStudentViewModel
{
    public Student Student { get; set; }
    public Group Group { get; set; }
    public string Reason { get; set; }
}
