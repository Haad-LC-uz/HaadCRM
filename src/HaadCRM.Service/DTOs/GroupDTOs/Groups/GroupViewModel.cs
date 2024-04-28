using HaadCRM.Domain.Entities.Courses;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Service.DTOs.Courses;
using HaadCRM.Service.DTOs.EmployeeDTOs.Employees;

namespace HaadCRM.Service.DTOs.GroupDTOs.Groups;

public class GroupViewModel
{
    public string Name { get; set; }
    public CourseViewModel Course { get; set; }
    public EmployeeViewModel Teacher { get; set; }
    public EmployeeViewModel Assistant { get; set; }
    public DateTime StartTime { get; set; }
    public int Duration { get; set; }
    public DateTime EndTime { get; set; }
    public decimal Price { get; set; }
    public string Room { get; set; }
}