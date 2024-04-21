using HaadCRM.Service.DTOs.EmployeeDTOs.Employees;
using HaadCRM.Service.DTOs.LessonsDTOs.Lessons;

namespace HaadCRM.Service.DTOs.HomeworkDTOs.Homework;

public class HomeworkViewModel
{
    public long Id { get; set; }
    public LessonViewModel Lesson { get; set; }
    public EmployeeViewModel Assistant { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DeadLine { get; set; }
}