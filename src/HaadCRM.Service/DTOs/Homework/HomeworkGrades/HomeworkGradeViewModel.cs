using HaadCRM.Service.DTOs.Employees;
using HaadCRM.Service.DTOs.Homeworks;
using HaadCRM.Service.DTOs.Students.StudentDTOs;

namespace HaadCRM.Service.DTOs.HomeworkGrades;

public class HomeworkGradeViewModel
{
    public long Id { get; set; }
    public StudentViewModel Student { get; set; }
    public EmployeeViewModel Assistant { get; set; }
    public HomeworkViewModel Homework { get; set; }
    public int Grade { get; set; }
}