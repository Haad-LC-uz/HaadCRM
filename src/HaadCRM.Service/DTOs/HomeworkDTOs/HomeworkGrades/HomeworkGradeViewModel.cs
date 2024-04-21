using HaadCRM.Service.DTOs.EmployeeDTOs.Employees;
using HaadCRM.Service.DTOs.HomeworkDTOs.Homework;
using HaadCRM.Service.DTOs.StudentDTOs.Students;

namespace HaadCRM.Service.DTOs.HomeworkDTOs.HomeworkGrades;

public class HomeworkGradeViewModel
{
    public long Id { get; set; }
    public StudentViewModel Student { get; set; }
    public EmployeeViewModel Assistant { get; set; }
    public HomeworkViewModel Homework { get; set; }
    public int Grade { get; set; }
}