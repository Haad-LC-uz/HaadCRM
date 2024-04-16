using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Lessons;

namespace HaadCRM.Service.DTOs.LessonFiles;

public class LessonFileViewModel
{
    public long Id { get; set; }
    public Lesson Lesson { get; set; }
    public Asset Asset { get; set; }
}
