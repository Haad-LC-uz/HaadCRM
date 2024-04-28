using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Domain.Entities.Groups;
using HaadCRM.Service.DTOs.Assets;
using HaadCRM.Service.DTOs.EmployeeDTOs.Employees;
using HaadCRM.Service.DTOs.GroupDTOs.Groups;

namespace HaadCRM.Service.DTOs.ExamDTOs.Exams;

public class ExamViewModel
{
    public EmployeeViewModel Teacher { get; set; }
    public EmployeeViewModel Assistant { get; set; }
    public GroupViewModel Group { get; set; }
    public AssetViewModel ProfilePicture { get; set; }
    public DateTime DateOfExam { get; set; }
    public DateTime DeadLine { get; set; }
}