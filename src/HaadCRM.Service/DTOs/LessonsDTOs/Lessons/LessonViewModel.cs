using System.Text.RegularExpressions;

namespace HaadCRM.Service.DTOs.LessonsDTOs.Lessons;

public class LessonViewModel
{
    public DateTime DateOfLesson { get; set; }
    public string Name { get; set; }
    public Group Group { get; set; }
}