using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Homeworks;
using HaadCRM.Service.DTOs.HomeworkDTOs.Homework;
using HaadCRM.Service.Exceptions;
using HaadCRM.Service.Extensions;
using HaadCRM.Service.Validators.Exams.ExamGrades;
using HaadCRM.Service.Validators.Homework.Homework;

namespace HaadCRM.Service.Services.HomeworkServices;

public class HomeworkService(
    IUnitOfWork unitOfWork, 
    IMapper mapper,
    HomeworkCreateModelValidator createModelValidator,
    HomeworkUpdateModelValidator updateModelValidator) : IHomeWorkService
{
    public async ValueTask<HomeworkViewModel> CreateAsync(HomeworkCreateModel createModel)
    {
        await createModelValidator.ValidateOrPanicAsync(createModel);
        var exist = await unitOfWork.Homework.SelectAsync(h => h.LessonId == createModel.LessonId
        && h.AssistantId == createModel.AssistantId);

        if (exist == null)
            throw new AlreadyExistException("Lesson or Assistant is not found");

        await unitOfWork.Homework.InsertAsync(mapper.Map<Homework>(createModel));
        await unitOfWork.SaveAsync();

        return mapper.Map<HomeworkViewModel>(createModel);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var homework = await unitOfWork.Homework.SelectAsync(h => h.Id == id && !h.IsDeleted);
        if (homework == null)
            throw new NotFoundException($"Homework with ID={id} is not found or was deleted");

        await unitOfWork.Homework.DeleteAsync(homework);
        await unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<IEnumerable<HomeworkViewModel>> GetAllAsync()
    {
        var homeworks = await unitOfWork.Homework.SelectAsEnumerableAsync(
            expression: h => !h.IsDeleted,
            includes: ["Lesson", "Assistant"]);

        return await Task.FromResult(mapper.Map<IEnumerable<HomeworkViewModel>>(homeworks));
    }

    public async ValueTask<HomeworkViewModel> GetByIdAsync(long id)
    {
        var homework = await unitOfWork.Homework.SelectAsync(h => h.Id == id && !h.IsDeleted);
        if (homework == null)
            throw new NotFoundException($"Homework with ID={id} is not found or was deleted");

        return await Task.FromResult(mapper.Map<HomeworkViewModel>(homework));
    }

    public async ValueTask<HomeworkViewModel> UpdateAsync(long id, HomeworkUpdateModel updateModel)
    {
        await updateModelValidator.ValidateOrPanicAsync(updateModel);
        var homework = await unitOfWork.Homework.SelectAsync(h => h.Id == id && !h.IsDeleted);
        if (homework == null)
            throw new NotFoundException($"Homework with ID={id} is not found or was deleted");

        await unitOfWork.Homework.UpdateAsync(homework);
        await unitOfWork.SaveAsync();
        return await Task.FromResult(mapper.Map<HomeworkViewModel>(homework));
    }
}
