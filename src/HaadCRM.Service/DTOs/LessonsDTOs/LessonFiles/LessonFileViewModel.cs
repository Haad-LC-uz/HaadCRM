using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Lessons;

namespace HaadCRM.Service.DTOs.LessonsDTOs.LessonFiles;

public class LessonFileViewModel
{
    public Lesson Lesson { get; set; }
    public Asset Asset { get; set; }
}
