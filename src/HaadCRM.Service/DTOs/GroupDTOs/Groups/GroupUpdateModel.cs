namespace HaadCRM.Service.DTOs.GroupDTOs.Groups;

public class GroupUpdateModel
{
    public long CourseId { get; set; }
    public long TeacherId { get; set; }
    public long AssistantId { get; set; }
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public int Duration { get; set; }
    public DateTime EndTime { get; set; }
    public decimal Price { get; set; }
    public string Room { get; set; }
}