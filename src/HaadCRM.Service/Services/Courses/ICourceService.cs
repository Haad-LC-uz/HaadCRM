using HaadCRM.Service.DTOs.Courses;

namespace HaadCRM.Service.Services.Courses;

public interface ICourceService
{
    Task<CourseViewModel> CreateAsync(CourseCreateModel course);
    Task<CourseUpdateModel> UpdateAsync(long id, CourseUpdateModel course);
    Task<bool> DeleteAsync(long id);
    Task<CourseViewModel> GetByIdAsync(long id);
    Task<IEnumerable<CourseViewModel>> GetAllAsync();
}
