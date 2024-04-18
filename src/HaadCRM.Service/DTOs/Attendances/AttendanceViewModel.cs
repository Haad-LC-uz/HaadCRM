namespace HaadCRM.Service.DTOs.Attendances;

public class AttendanceViewModel
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long LessonId { get; set; }
    public bool IsAttended { get; set; }
}