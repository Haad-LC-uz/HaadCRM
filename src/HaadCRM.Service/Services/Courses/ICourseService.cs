using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.Courses;

namespace HaadCRM.Service.Services.Courses;

public interface ICourseService
{
    /// <summary>
    /// Creates new Course
    /// </summary>
    /// <param name="course"></param>
    /// <returns></returns>
    ValueTask<CourseViewModel> CreateAsync(CourseCreateModel course);
    /// <summary>
    /// Updates exist Course
    /// </summary>
    /// <param name="id"></param>
    /// <param name="course"></param>
    /// <returns></returns>
    ValueTask<CourseViewModel> UpdateAsync(long id, CourseUpdateModel course);
    /// <summary>
    /// Deletes exist Course
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<bool> DeleteAsync(long id);
    /// <summary>
    /// Gets Course by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<CourseViewModel> GetByIdAsync(long id);
    /// <summary>
    /// Will get all Courses and returns IEnumerable
    /// </summary>
    /// <returns></returns>
    ValueTask<IEnumerable<CourseViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
