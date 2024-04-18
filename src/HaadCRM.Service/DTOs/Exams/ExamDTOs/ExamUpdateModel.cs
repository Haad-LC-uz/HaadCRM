namespace HaadCRM.Service.DTOs.Exams.ExamDTOs;

public class ExamUpdateModel
{
    public long TeacherId { get; set; }
    public long AssistantId { get; set; }
    public long GroupId { get; set; }
    public long AssetId { get; set; }
    public DateTime DateOfExam { get; set; }
    public DateTime DeadLine { get; set; }
}