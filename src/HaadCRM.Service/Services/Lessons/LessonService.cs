using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Lessons;
using HaadCRM.Service.DTOs.LessonsDTOs.Lessons;
using HaadCRM.Service.Exceptions;
using HaadCRM.Service.Extensions;
using HaadCRM.Service.Validators.Exams.ExamGrades;
using HaadCRM.Service.Validators.Lessons.Lessons;

namespace HaadCRM.Service.Services.Lessons;

public class LessonService(
    IMapper mapper, 
    IUnitOfWork unitOfWork,
    LessonCreateModelValidator createModelValidator,
    LessonUpdateModelValidator updateModelValidator) : ILessonService
{
    public async ValueTask<LessonViewModel> CreateAsync(LessonCreateModel lesson)
    {
        await createModelValidator.ValidateOrPanicAsync(lesson);
        var existGroup = await unitOfWork.Groups.SelectAsync(
            expression: g => g.Id == lesson.GroupId && !g.IsDeleted)
            ?? throw new NotFoundException($"Group is not found with Id = {lesson.GroupId}");

        var existLesson = await unitOfWork.Lessons.SelectAsync(
           expression: l => l.Name == lesson.Name && !l.IsDeleted,
           includes: ["Group"]);

        if (existLesson is not null)
            throw new AlreadyExistException($"Lesson is already exist with Name = {lesson.Name}");

        var createdLesson = await unitOfWork.Lessons.InsertAsync(mapper.Map<Lesson>(lesson));
        createdLesson.Group = existGroup;
        await unitOfWork.SaveAsync();

        return mapper.Map<LessonViewModel>(createdLesson);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existLesson = await unitOfWork.Lessons.SelectAsync(
            expression: l => l.Id == id && !l.IsDeleted)
            ?? throw new NotFoundException($"Lesson is not found with Id = {id}");

        await unitOfWork.Lessons.DeleteAsync(existLesson);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<LessonViewModel>> GetAllAsync()
    {
        var Lessons = await unitOfWork.Lessons.SelectAsEnumerableAsync(
            expression: l => !l.IsDeleted,
            includes: ["Group"]);

        return mapper.Map<IEnumerable<LessonViewModel>>(Lessons);
    }

    public async ValueTask<LessonViewModel> GetByIdAsync(long id)
    {
        var existLesson = await unitOfWork.Lessons.SelectAsync(
            expression: l => l.Id == id && !l.IsDeleted,
            includes: ["Group"])
            ?? throw new NotFoundException($"Lesson is not found with Id = {id}");

        return mapper.Map<LessonViewModel>(existLesson);
    }

    public async ValueTask<LessonViewModel> UpdateAsync(long id, LessonUpdateModel lesson)
    {
        await updateModelValidator.ValidateOrPanicAsync(lesson);
        var existGroup = await unitOfWork.Groups.SelectAsync(
            expression: g => g.Id == lesson.GroupId && !g.IsDeleted)
            ?? throw new NotFoundException($"Group is not found with Id = {lesson.GroupId}");

        var existLesson = await unitOfWork.Lessons.SelectAsync(
           expression: l => l.Id == id && !l.IsDeleted,
           includes: ["Group"])
            ?? throw new NotFoundException($"Lesson is not found with Id = {id}");

        var mapped = mapper.Map(lesson, existLesson);
        var updated = await unitOfWork.Lessons.UpdateAsync(mapped);
        updated.Group = existGroup;
        await unitOfWork.SaveAsync();

        return mapper.Map<LessonViewModel>(updated);
    }
}
