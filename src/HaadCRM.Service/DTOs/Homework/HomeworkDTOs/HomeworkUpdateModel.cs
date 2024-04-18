namespace HaadCRM.Service.DTOs.Homeworks;

public class HomeworkUpdateModel
{
    public long LessonId { get; set; }
    public long AssistantId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DeadLine { get; set; }
}