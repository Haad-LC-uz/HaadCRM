using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Lessons;
using HaadCRM.Service.DTOs.LessonsDTOs.LessonFiles;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.LessonFiles;

public class LessonFilesService(IMapper mapper, IUnitOfWork unitOfWork) : ILessonFilesService
{
    public async ValueTask<LessonFileViewModel> CreateAsync(LessonFileViewModel lessonfile)
    {
        var existAsset = await unitOfWork.Assets.SelectAsync(
            expression: a => a.Id == lessonfile.AssetId && !a.IsDeleted)
            ?? throw new NotFoundException($"Asset with Id = {lessonfile.AssetId} is not found");

        var existLesson = await unitOfWork.Lessons.SelectAsync(
            expression: l => l.Id == lessonfile.LessonId && !l.IsDeleted)
            ?? throw new NotFoundException($"Lesson with Id = {lessonfile.LessonId} is not found");

        var existLessonFile = await unitOfWork.LessonFiles.SelectAsync(
            expression: lf => lf.AssetId == lessonfile.AssetId && lf.LessonId == lessonfile.LessonId && !lf.IsDeleted);

        if (existLessonFile is not null)
            throw new AlreadyExistException($"Lessonfile with LessonId = {lessonfile.LessonId} and AssetId = {lessonfile.AssetId} is already exists");

        var createdLessonfile = await unitOfWork.LessonFiles.InsertAsync(mapper.Map<LessonFile>(lessonfile));
        await unitOfWork.SaveAsync();

        return mapper.Map<LessonFileViewModel>(createdLessonfile);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existLessonFile = await unitOfWork.LessonFiles.SelectAsync(
            expression: lf => lf.Id == id && !lf.IsDeleted)
            ?? throw new NotFoundException($"Lessonfile with Id = {id} is not found");

        await unitOfWork.LessonFiles.DeleteAsync(existLessonFile);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<LessonFileViewModel>> GetAllAsync()
    {
        var Lessons = await unitOfWork.Lessons.SelectAsEnumerableAsync(
            expression: lf => !lf.IsDeleted);

        return mapper.Map<IEnumerable<LessonFileViewModel>>(Lessons);
    }

    public async ValueTask<LessonFileViewModel> GetByIdAsync(long id)
    {
        var existLessonFile = await unitOfWork.LessonFiles.SelectAsync(
            expression: lf => lf.Id == id && !lf.IsDeleted)
            ?? throw new NotFoundException($"Lessonfile with Id = {id} is not found");

        return mapper.Map<LessonFileViewModel>(existLessonFile);
    }

    public async ValueTask<LessonFileViewModel> UpdateAsync(long id, LessonFileUpdateModel lessonfile)
    {
        var existAsset = await unitOfWork.Assets.SelectAsync(
            expression: a => a.Id == lessonfile.AssetId && !a.IsDeleted)
            ?? throw new NotFoundException($"Asset with Id = {lessonfile.AssetId} is not found");

        var existLesson = await unitOfWork.Lessons.SelectAsync(
            expression: l => l.Id == lessonfile.LessonId && !l.IsDeleted)
            ?? throw new NotFoundException($"Lesson with Id = {lessonfile.LessonId} is not found");

        var existLessonFile = await unitOfWork.LessonFiles.SelectAsync(
            expression: lf => lf.Id == id && !lf.IsDeleted)
            ?? throw new NotFoundException($"Lessonfile with Id = {id} is not found");

        var mapped = mapper.Map(lessonfile, existLessonFile);
        var updated = await unitOfWork.LessonFiles.UpdateAsync(mapped);
        await unitOfWork.SaveAsync();

        return mapper.Map<LessonFileViewModel>(updated);
    }
}
