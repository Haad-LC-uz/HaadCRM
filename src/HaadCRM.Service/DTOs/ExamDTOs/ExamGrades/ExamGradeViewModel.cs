using HaadCRM.Service.DTOs.EmployeeDTOs.Employees;
using HaadCRM.Service.DTOs.StudentDTOs.Students;

namespace HaadCRM.Service.DTOs.ExamDTOs.ExamGrades;

public class ExamGradeViewModel
{
    public int Grade { get; set; }
    public StudentViewModel Student { get; set; }
    public ExamGradeViewModel Exam { get; set; }
    public EmployeeViewModel Teacher { get; set; }
    public EmployeeViewModel Assistant { get; set; }
}