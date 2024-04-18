using HaadCRM.Service.DTOs.Courses;

namespace HaadCRM.Service.Services.Courses;

public class CourseService : ICourceService
{
    public Task<CourseViewModel> CreateAsync(CourseCreateModel course)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<CourseViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<CourseViewModel> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public Task<CourseUpdateModel> UpdateAsync(long id, CourseUpdateModel course)
    {
        throw new NotImplementedException();
    }
}