using HaadCRM.Service.DTOs.LessonsDTOs.Lessons;

namespace HaadCRM.Service.Services.Lessons;

public interface LessonService
{
    Task<LessonViewModel> CreateAsync(LessonCreateModel lesson);
    Task<LessonViewModel> UpdateAsync(long id, LessonUpdateModel lesson);
    Task<bool> DeleteAsync(long id);
    Task<LessonViewModel> GetByIdAsync(long id);
    Task<IEnumerable<LessonViewModel>> GetAllAsync();
}
