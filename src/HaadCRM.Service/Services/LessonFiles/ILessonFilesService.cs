using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.LessonsDTOs.LessonFiles;

namespace HaadCRM.Service.Services.LessonFiles;

public interface ILessonFilesService
{
    /// <summary>
    /// Creates new LessonFile
    /// </summary>
    /// <param name="lessonfile"></param>
    /// <returns></returns>
    ValueTask<LessonFileViewModel> CreateAsync(LessonFileCreateModel lessonFile);
    /// <summary>
    /// Updates exist LessonFile
    /// </summary>
    /// <param name="id"></param>
    /// <param name="lessonfile"></param>
    /// <returns></returns>
    ValueTask<LessonFileViewModel> UpdateAsync(long id, LessonFileUpdateModel lessonFile);
    /// <summary>
    /// Deletes exist LessonFile
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<bool> DeleteAsync(long id);
    /// <summary>
    /// Gets LessonFile by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<LessonFileViewModel> GetByIdAsync(long id);
    /// <summary>
    /// Will get all LessonFiles and returns IEnumerable
    /// </summary>
    /// <returns></returns>
    ValueTask<IEnumerable<LessonFileViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
