using HaadCRM.Service.DTOs.LessonsDTOs.LessonFiles;

namespace HaadCRM.Service.Services.LessonFiles;

public interface ILessonFilesService
{
    Task<LessonFileViewModel> CreateAsync(LessonFileViewModel lessonfile);
    Task<LessonFileViewModel> UpdateAsync(long id, LessonFileUpdateModel lessonfile);
    Task<bool> DeleteAsync(long id);
    Task<LessonFileViewModel> GetByIdAsync(long id);
    Task<IEnumerable<LessonFileViewModel>> GetAllAsync();
}
