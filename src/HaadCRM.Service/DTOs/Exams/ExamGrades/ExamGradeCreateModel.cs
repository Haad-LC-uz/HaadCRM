namespace HaadCRM.Service.DTOs.ExamGrades;

public class ExamGradeCreateModel
{
    public long StudentId { get; set; }
    public long ExamId { get; set; }
    public long TeacherId { get; set; }
    public long AssistantId { get; set; }
    public int Grade { get; set; }
}