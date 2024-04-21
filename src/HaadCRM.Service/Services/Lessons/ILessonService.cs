using HaadCRM.Service.DTOs.LessonsDTOs.Lessons;

namespace HaadCRM.Service.Services.Lessons;

public interface ILessonService
{
    /// <summary>
    /// Creates new Lesson
    /// </summary>
    /// <param name="lesson"></param>
    /// <returns></returns>
    ValueTask<LessonViewModel> CreateAsync(LessonCreateModel lesson);
    /// <summary>
    /// Updates exist Lesson
    /// </summary>
    /// <param name="id"></param>
    /// <param name="lesson"></param>
    /// <returns></returns>
    ValueTask<LessonViewModel> UpdateAsync(long id, LessonUpdateModel lesson);
    /// <summary>
    /// Deletes exist Lesson
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<bool> DeleteAsync(long id);
    /// <summary>
    /// Gets Lesson by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<LessonViewModel> GetByIdAsync(long id);
    /// <summary>
    /// Will get all Lessons and returns IEnumerable
    /// </summary>
    /// <returns></returns>
    ValueTask<IEnumerable<LessonViewModel>> GetAllAsync();
}
