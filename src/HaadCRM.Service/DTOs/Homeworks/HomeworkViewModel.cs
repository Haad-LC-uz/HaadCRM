using HaadCRM.Service.DTOs.Employees;
using HaadCRM.Service.DTOs.Lessons;

namespace HaadCRM.Service.DTOs.Homeworks;

public class HomeworkViewModel
{
    public long Id { get; set; }
    public LessonViewModel Lesson { get; set; }
    public EmployeeViewModel Assistant { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DeadLine { get; set; }
}