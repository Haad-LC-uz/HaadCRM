namespace HaadCRM.Service.DTOs.StudentDTOs.RemovedStudents;

public class RemovedStudentCreateModel
{
    public long StudentId { get; set; }
    public long GroupId { get; set; }
    public string Reason { get; set; }
}
