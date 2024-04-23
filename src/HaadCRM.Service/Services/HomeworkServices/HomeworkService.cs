using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Homeworks;
using HaadCRM.Service.DTOs.HomeworkDTOs.Homework;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.HomeworkServices;

public class HomeworkService(IUnitOfWork unitOfWork, IMapper mapper) : IHomeWorkService
{
    public async ValueTask<HomeworkViewModel> CreateAsync(HomeworkCreateModel createModel)
    {
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
        var homework = await unitOfWork.Homework.SelectAsync(h => h.Id == id && !h.IsDeleted);
        if (homework == null)
            throw new NotFoundException($"Homework with ID={id} is not found or was deleted");

        await unitOfWork.Homework.UpdateAsync(homework);
        await unitOfWork.SaveAsync();
        return await Task.FromResult(mapper.Map<HomeworkViewModel>(homework));
    }
}
