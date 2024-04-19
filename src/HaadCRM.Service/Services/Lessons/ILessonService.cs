using HaadCRM.Service.DTOs.LessonsDTOs.Lessons;

namespace HaadCRM.Service.Services.Lessons;

public interface ILessonService
{
    ValueTask<LessonViewModel> CreateAsync(LessonCreateModel lesson);
    ValueTask<LessonViewModel> UpdateAsync(long id, LessonUpdateModel lesson);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<LessonViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<LessonViewModel>> GetAllAsync();
}
