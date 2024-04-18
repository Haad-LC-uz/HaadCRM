namespace HaadCRM.Service.DTOs.LessonsDTOs.Lessons;

public class LessonCreateModel
{
    public long GroupId { get; set; }
    public DateTime DateOfLesson { get; set; }
    public string Name { get; set; }
}