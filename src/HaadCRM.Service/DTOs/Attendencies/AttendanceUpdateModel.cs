namespace HaadCRM.Service.DTOs.Attendencies;

public class AttendanceUpdateModel
{
    public long StudentId { get; set; }
    public long LessonId { get; set; }
    public bool IsAttended { get; set; }
}
