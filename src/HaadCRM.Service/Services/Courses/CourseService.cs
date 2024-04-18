using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Service.DTOs.Courses;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.Courses;

public class CourseService(IMapper mapper, IUnitOfWork unitOfWork) : ICourceService
{
    public async Task<CourseViewModel> CreateAsync(CourseCreateModel course)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(
            expression: c => c.Name == course.Name);

        if (existCourse is not null)
            throw new AlreadyExistException($"Course already exist with Name = {course.Name}");

        var createdCourse = await unitOfWork.Courses.InsertAsync(existCourse);
        await unitOfWork.SaveAsync();

        return mapper.Map<CourseViewModel>(createdCourse);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(expression: c => c.Id == id)
            ?? throw new NotFoundException($"Couse is not found with Id = {id}");

        await unitOfWork.Courses.DeleteAsync(existCourse);
        await unitOfWork.SaveAsync();

        return true;
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