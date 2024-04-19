using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Service.DTOs.Courses;
using HaadCRM.Service.Exceptions;
using AutoMapper;

namespace HaadCRM.Service.Services.Courses;

public class CourseService(IMapper mapper, IUnitOfWork unitOfWork) : ICourceService
{
    public async Task<CourseViewModel> CreateAsync(CourseCreateModel course)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(
            expression: c => c.Name == course.Name && !c.IsDeleted);

        if (existCourse is not null)
            throw new AlreadyExistException($"Course already exist with Name = {course.Name}");

        var createdCourse = await unitOfWork.Courses.InsertAsync(existCourse);
        await unitOfWork.SaveAsync();

        return mapper.Map<CourseViewModel>(createdCourse);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(
            expression: c => c.Id == id && !c.IsDeleted)
            ?? throw new NotFoundException($"Couse is not found with Id = {id}");

        await unitOfWork.Courses.DeleteAsync(existCourse);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async Task<IEnumerable<CourseViewModel>> GetAllAsync()
    {
        var Courses = await unitOfWork.Courses.SelectAsEnumerableAsync(
            expression: c => !c.IsDeleted);

        return mapper.Map<IEnumerable<CourseViewModel>>(Courses);
    }

    public async Task<CourseViewModel> GetByIdAsync(long id)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(
            expression: c => !c.IsDeleted)
            ?? throw new NotFoundException($"Couse is not found with Id = {id}");

        return mapper.Map<CourseViewModel>(existCourse);
    }

    public async Task<CourseViewModel> UpdateAsync(long id, CourseUpdateModel course)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(
            expression: c => c.Id == id && !c.IsDeleted)
            ?? throw new NotFoundException($"Couse is not found with Id = {id}");

        var mapped = mapper.Map(course, existCourse);
        var updated = await unitOfWork.Courses.UpdateAsync(mapped);
        await unitOfWork.SaveAsync();

        return mapper.Map<CourseViewModel>(course);
    }
}