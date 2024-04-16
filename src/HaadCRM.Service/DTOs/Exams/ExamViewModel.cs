namespace HaadCRM.Service.DTOs.Exams;

public class ExamViewModel
{
    public long Id { get; set; }
    public long TeacherId { get; set; }
    public long AssistantId { get; set; }
    public long GroupId { get; set; }
    public string PicturePath { get; set; }
    public DateTime DateOfExam { get; set; }
    public DateTime DeadLine { get; set; }
}