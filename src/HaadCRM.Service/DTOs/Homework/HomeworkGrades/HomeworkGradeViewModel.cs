namespace HaadCRM.Service.DTOs.HomeworkGrades;

public class HomeworkGradeViewModel
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long AssistantId { get; set; }
    public long HomeworkId { get; set; }
    public int Grade { get; set; }
}