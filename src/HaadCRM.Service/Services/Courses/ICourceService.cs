using HaadCRM.Service.DTOs.Courses;

namespace HaadCRM.Service.Services.Courses;

public interface ICourceService
{
    ValueTask<CourseViewModel> CreateAsync(CourseCreateModel course);
    ValueTask<CourseViewModel> UpdateAsync(long id, CourseUpdateModel course);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<CourseViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<CourseViewModel>> GetAllAsync();
}
