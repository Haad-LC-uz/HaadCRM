namespace HaadCRM.Service.DTOs.Lessons;

public class LessonCreateModel
{
    public long GroupId { get; set; }
    public DateTime DateOfLesson { get; set; }
    public string Name { get; set; }
}