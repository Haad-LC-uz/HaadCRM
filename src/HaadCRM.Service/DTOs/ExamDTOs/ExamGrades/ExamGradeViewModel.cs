namespace HaadCRM.Service.DTOs.ExamDTOs.ExamGrades;

public class ExamGradeViewModel
{
    public long Id { get; set; }
    public long StudentId { get; set; }
    public long ExamId { get; set; }
    public long TeacherId { get; set; }
    public long AssistantId { get; set; }
    public int Grade { get; set; }
}