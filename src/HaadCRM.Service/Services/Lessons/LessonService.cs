using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Lessons;
using HaadCRM.Service.DTOs.LessonsDTOs.Lessons;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.Lessons;

public class LessonService(IMapper mapper, IUnitOfWork unitOfWork) : ILessonService
{
    public async Task<LessonViewModel> CreateAsync(LessonCreateModel lesson)
    {
        var existGroup = await unitOfWork.Groups.SelectAsync(
            expression: g => g.Id == lesson.GroupId && !g.IsDeleted)
            ?? throw new NotFoundException($"Group not found with Id = {lesson.GroupId}");

        var existLesson = await unitOfWork.Lessons.SelectAsync(
            expression:
            l => l.Name == lesson.Name && !l.IsDeleted);

        if (existLesson is not null)
            throw new AlreadyExistException($"Lesson is already exist with Name = {lesson.Name}");

        var createdLesson = await unitOfWork.Lessons.InsertAsync(mapper.Map<Lesson>(lesson));
        await unitOfWork.SaveAsync();

        return mapper.Map<LessonViewModel>(createdLesson);
    }

    public async Task<bool> DeleteAsync(long id)
    {
        var existLesson = await unitOfWork.Lessons.SelectAsync(
            expression: l => l.Id == id && !l.IsDeleted)
            ?? throw new NotFoundException($"Lesson is not found with Id = {id}");

        await unitOfWork.Lessons.DeleteAsync(existLesson);
        await unitOfWork.SaveAsync();

        return true;
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
