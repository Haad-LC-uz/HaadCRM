using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Service.DTOs.Courses;
using HaadCRM.Service.Exceptions;
using HaadCRM.Service.Extensions;
using HaadCRM.Service.Validators.Attendances;
using HaadCRM.Service.Validators.Cources;

namespace HaadCRM.Service.Services.Courses;

public class CourseService(
    IMapper mapper, 
    IUnitOfWork unitOfWork,
    CourseCreateModelValidator createModelValidator,
    CourseUpdateModelValidator updateModelValidator) : ICourseService
{
    public async ValueTask<CourseViewModel> CreateAsync(CourseCreateModel course)
    {
        await createModelValidator.ValidateOrPanicAsync(course);

        var existCourse = await unitOfWork.Courses.SelectAsync(
            expression: c => c.Name == course.Name && !c.IsDeleted);

        if (existCourse is not null)
            throw new AlreadyExistException($"Course is already exist with Name = {course.Name}");

        var createdCourse = await unitOfWork.Courses.InsertAsync(existCourse);
        await unitOfWork.SaveAsync();

        return mapper.Map<CourseViewModel>(createdCourse);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(
            expression: c => c.Id == id && !c.IsDeleted)
            ?? throw new NotFoundException($"Course is not found with Id = {id}");

        await unitOfWork.Courses.DeleteAsync(existCourse);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<CourseViewModel>> GetAllAsync()
    {
        var Courses = await unitOfWork.Courses.SelectAsEnumerableAsync(
            expression: c => !c.IsDeleted);

        return mapper.Map<IEnumerable<CourseViewModel>>(Courses);
    }

    public async ValueTask<CourseViewModel> GetByIdAsync(long id)
    {
        var existCourse = await unitOfWork.Courses.SelectAsync(
            expression: c => !c.IsDeleted)
            ?? throw new NotFoundException($"Course is not found with Id = {id}");

        return mapper.Map<CourseViewModel>(existCourse);
    }

    public async ValueTask<CourseViewModel> UpdateAsync(long id, CourseUpdateModel course)
    {
        await updateModelValidator.ValidateOrPanicAsync(course);

        var existCourse = await unitOfWork.Courses.SelectAsync(
            expression: c => c.Id == id && !c.IsDeleted)
            ?? throw new NotFoundException($"Course is not found with Id = {id}");

        var mapped = mapper.Map(course, existCourse);
        var updated = await unitOfWork.Courses.UpdateAsync(mapped);
        await unitOfWork.SaveAsync();

        return mapper.Map<CourseViewModel>(course);
    }
}