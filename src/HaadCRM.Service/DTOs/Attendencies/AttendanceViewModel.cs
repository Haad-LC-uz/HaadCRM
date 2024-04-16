using HaadCRM.Domain.Entities.Lessons;
using HaadCRM.Domain.Entities.Students;

namespace HaadCRM.Service.DTOs.Attendencies;

public class AttendanceViewModel
{
    public long Id { get; set; }
    public Student Student { get; set; }
    public Lesson Lesson { get; set; }
    public bool IsAttended { get; set; }
}