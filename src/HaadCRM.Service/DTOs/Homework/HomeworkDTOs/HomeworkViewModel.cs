namespace HaadCRM.Service.DTOs.Homework;

public class HomeworkViewModel
{
    public long Id { get; set; }
    public long LessonId { get; set; }
    public long AssistantId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DeadLine { get; set; }
}