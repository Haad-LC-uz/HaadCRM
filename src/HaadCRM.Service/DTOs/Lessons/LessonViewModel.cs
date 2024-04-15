using HaadCRM.Service.DTOs.Groups;

namespace HaadCRM.Service.DTOs.Lessons;

public class LessonViewModel
{
    public long Id { get; set; }
    public GroupViewModel Group { get; set; }
    public string Name { get; set; }
}