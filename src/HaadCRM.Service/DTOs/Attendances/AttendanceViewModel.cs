using HaadCRM.Domain.Entities.Students;
using HaadCRM.Service.DTOs.LessonsDTOs.Lessons;
using HaadCRM.Service.DTOs.StudentDTOs.Students;

namespace HaadCRM.Service.DTOs.Attendances;

public class AttendanceViewModel
{
    public bool IsAttended { get; set; }
    public StudentViewModel Student { get; set; }
    public LessonViewModel Lesson { get; set; }
}