namespace HaadCRM.Service.DTOs.HomeworkDTOs.HomeworkGrades;

public class HomeworkGradeUpdateModel
{
    public long StudentId { get; set; }
    public long AssistantId { get; set; }
    public long HomeworkId { get; set; }
    public int Grade { get; set; }
}