using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Domain.Entities.Groups;

namespace HaadCRM.Service.DTOs.ExamDTOs.Exams;

public class ExamViewModel
{
    public long Id { get; set; }
    public Employee Teacher { get; set; }
    public Employee Assistant { get; set; }
    public Group Group { get; set; }
    public Asset Asset { get; set; }
    public DateTime DateOfExam { get; set; }
    public DateTime DeadLine { get; set; }
}