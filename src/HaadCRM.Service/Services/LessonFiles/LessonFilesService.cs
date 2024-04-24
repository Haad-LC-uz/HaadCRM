using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Lessons;
using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.LessonsDTOs.LessonFiles;
using HaadCRM.Service.Exceptions;
using HaadCRM.Service.Extensions;
using HaadCRM.Service.Validators.Exams.ExamGrades;
using HaadCRM.Service.Validators.Lessons.LessonFiles;

namespace HaadCRM.Service.Services.LessonFiles;

public class LessonFilesService(
    IMapper mapper, 
    IUnitOfWork unitOfWork,
    LessonFileCreateModelValidator createModelValidator,
    LessonFileUpdateModelValidator updateModelValidator) : ILessonFilesService
{
    public async ValueTask<LessonFileViewModel> CreateAsync(LessonFileCreateModel lessonFile)
    {
        await createModelValidator.ValidateOrPanicAsync(lessonFile);

        var existAsset = await unitOfWork.Assets.SelectAsync(
            expression: a => a.Id == lessonFile.AssetId && !a.IsDeleted)
            ?? throw new NotFoundException($"Asset with Id = {lessonFile.AssetId} is not found");

        var existLesson = await unitOfWork.Lessons.SelectAsync(
            expression: l => l.Id == lessonFile.LessonId && !l.IsDeleted)
            ?? throw new NotFoundException($"Lesson with Id = {lessonFile.LessonId} is not found");

        var existLessonFile = await unitOfWork.LessonFiles.SelectAsync(
            expression: lf => lf.AssetId == lessonFile.AssetId && lf.LessonId == lessonFile.LessonId && !lf.IsDeleted);

        if (existLessonFile is not null)
            throw new AlreadyExistException($"LessonFile with LessonId = {lessonFile.LessonId} and AssetId = {lessonFile.AssetId} is already exists");

        var createdLessonFile = await unitOfWork.LessonFiles.InsertAsync(mapper.Map<LessonFile>(lessonFile));
        await unitOfWork.SaveAsync();

        return mapper.Map<LessonFileViewModel>(createdLessonFile);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existLessonFile = await unitOfWork.LessonFiles.SelectAsync(
            expression: lf => lf.Id == id && !lf.IsDeleted)
            ?? throw new NotFoundException($"LessonFile with Id = {id} is not found");

        await unitOfWork.LessonFiles.DeleteAsync(existLessonFile);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<LessonFileViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var Lessons = unitOfWork.Lessons.SelectAsQueryable(
            expression: lf => !lf.IsDeleted,
            isTracked: false).OrderBy(filter);

        return mapper.Map<IEnumerable<LessonFileViewModel>>(Lessons);
    }

    public async ValueTask<LessonFileViewModel> GetByIdAsync(long id)
    {
        var existLessonFile = await unitOfWork.LessonFiles.SelectAsync(
            expression: lf => lf.Id == id && !lf.IsDeleted)
            ?? throw new NotFoundException($"LessonFile with Id = {id} is not found");

        return mapper.Map<LessonFileViewModel>(existLessonFile);
    }

    public async ValueTask<LessonFileViewModel> UpdateAsync(long id, LessonFileUpdateModel lessonFile)
    {
        await updateModelValidator.ValidateOrPanicAsync(lessonFile);

        var existAsset = await unitOfWork.Assets.SelectAsync(
            expression: a => a.Id == lessonFile.AssetId && !a.IsDeleted)
            ?? throw new NotFoundException($"Asset with Id = {lessonFile.AssetId} is not found");

        var existLesson = await unitOfWork.Lessons.SelectAsync(
            expression: l => l.Id == lessonFile.LessonId && !l.IsDeleted)
            ?? throw new NotFoundException($"Lesson with Id = {lessonFile.LessonId} is not found");

        var existLessonFile = await unitOfWork.LessonFiles.SelectAsync(
            expression: lf => lf.Id == id && !lf.IsDeleted)
            ?? throw new NotFoundException($"LessonFile with Id = {id} is not found");

        var mapped = mapper.Map(lessonFile, existLessonFile);
        var updated = await unitOfWork.LessonFiles.UpdateAsync(mapped);
        await unitOfWork.SaveAsync();

        return mapper.Map<LessonFileViewModel>(updated);
    }
}
