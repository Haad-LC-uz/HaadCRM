using HaadCRM.Service.DTOs.Courses;
using HaadCRM.Service.DTOs.Employees;

namespace HaadCRM.Service.DTOs.Groups;

public class GroupViewModel
{
    public long Id { get; set; }
    public CourseViewModel Course { get; set; }
    public EmployeeViewModel Teacher { get; set; }
    public EmployeeViewModel Assistant { get; set; }
    public string Name { get; set; }
    public DateTime StartTime { get; set; }
    public int Duration { get; set; }
    public DateTime EndTime { get; set; }
    public decimal Price { get; set; }
    public string Room { get; set; }
}