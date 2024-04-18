namespace HaadCRM.Service.DTOs.Attendances;

public class AttendanceCreateModel
{
    public long StudentId { get; set; }
    public long LessonId { get; set; }
    public bool IsAttended { get; set; }
}
