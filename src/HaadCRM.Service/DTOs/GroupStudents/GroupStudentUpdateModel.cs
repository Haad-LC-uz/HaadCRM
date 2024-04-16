namespace HaadCRM.Service.DTOs.GroupStudents;

public class GroupStudentUpdateModel
{
    public long GroupId { get; set; }
    public long StudentId { get; set; }
    public bool IsPaid { get; set; }
    public bool IsPassed { get; set; }
}
