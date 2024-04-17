using HaadCRM.Service.DTOs.Assets;
using HaadCRM.Service.DTOs.Employees;
using HaadCRM.Service.DTOs.Groups;

namespace HaadCRM.Service.DTOs.Exams;

public class ExamViewModel
{
    public long Id { get; set; }
    public EmployeeViewModel Teacher { get; set; }
    public EmployeeViewModel Assistant { get; set; }
    public GroupViewModel Group { get; set; }
    public AssetViewModel ProfilePicture { get; set; }
    public DateTime DateOfExam { get; set; }
    public DateTime DeadLine { get; set; }
}