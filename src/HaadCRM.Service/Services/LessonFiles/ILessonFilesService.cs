using HaadCRM.Service.DTOs.LessonsDTOs.LessonFiles;

namespace HaadCRM.Service.Services.LessonFiles;

public interface ILessonFilesService
{
    ValueTask<LessonFileViewModel> CreateAsync(LessonFileViewModel lessonfile);
    ValueTask<LessonFileViewModel> UpdateAsync(long id, LessonFileUpdateModel lessonfile);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<LessonFileViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<LessonFileViewModel>> GetAllAsync();
}
