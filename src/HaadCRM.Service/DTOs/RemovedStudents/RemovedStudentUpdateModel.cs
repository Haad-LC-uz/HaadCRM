namespace HaadCRM.Service.DTOs.RemovedStudents;

public class RemovedStudentUpdateModel
{
    public long StudentId { get; set; }
    public long GroupId { get; set; }
    public string Reason { get; set; }
}
