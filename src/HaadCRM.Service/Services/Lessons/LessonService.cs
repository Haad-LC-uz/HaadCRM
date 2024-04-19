using HaadCRM.Service.DTOs.LessonsDTOs.Lessons;

namespace HaadCRM.Service.Services.Lessons;

public class LessonService : ILessonService
{
    public Task<LessonViewModel> CreateAsync(LessonCreateModel lesson)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<LessonViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<LessonViewModel> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<LessonViewModel> UpdateAsync(long id, LessonUpdateModel lesson)
    {
        throw new NotImplementedException();
    }
}
