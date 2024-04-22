using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Homeworks;
using HaadCRM.Service.DTOs.HomeworkDTOs.HomeworkGrades;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.Homeworks.HomeworkGrades;

public class HomeworkGradeService(IUnitOfWork unitOfWork, IMapper mapper) : IHomeworkGradeService
{
    public async ValueTask<HomeworkGradeViewModel> CreateAsync(HomeworkGradeCreateModel createModel)
    {
        var homeworkGrade = await unitOfWork.HomeworkGrades.SelectAsync(hg =>
        hg.HomeworkId == createModel.HomeworkId
        && hg.AssistantId == createModel.AssistantId
        && hg.StudentId == createModel.StudentId);

        if (homeworkGrade is null)
            throw new NotFoundException("Something is wrong! Try enter correctly ID");

        await unitOfWork.HomeworkGrades.InsertAsync(mapper.Map<HomeworkGrade>(createModel));
        await unitOfWork.SaveAsync();

        return await Task.FromResult(mapper.Map<HomeworkGradeViewModel>(createModel));
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var homeworkGrade = await unitOfWork.HomeworkGrades.SelectAsync(hg => hg.Id == id && !hg.IsDeleted);
        if (homeworkGrade is null)
            throw new NotFoundException($"HomeworkGrade with ID={id} is not found");

        await unitOfWork.HomeworkGrades.DeleteAsync(homeworkGrade);
        await unitOfWork.SaveAsync();

        return await Task.FromResult(true);
    }

    public async ValueTask<IEnumerable<HomeworkGradeViewModel>> GetAllAsync()
    {
        var homeworkGrades = await unitOfWork.HomeworkGrades.SelectAsEnumerableAsync(
            expression: hg => !hg.IsDeleted,
            includes: ["Homework", "Student", "Assistant"]);

        return mapper.Map<IEnumerable<HomeworkGradeViewModel>>(homeworkGrades);
    }

    public async ValueTask<HomeworkGradeViewModel> GetByIdAsync(long id)
    {
        var homeworkGrade = await unitOfWork.HomeworkGrades.SelectAsync(hg => hg.Id == id && !hg.IsDeleted);
        if (homeworkGrade is null)
            throw new NotFoundException($"Homework Grade with ID={id} is not FOUND");

        return mapper.Map<HomeworkGradeViewModel>(homeworkGrade);
    }

    public async ValueTask<HomeworkGradeViewModel> UpdateAsync(long id, HomeworkGradeUpdateModel updateModel)
    {
        var homeworkGrade = await unitOfWork.HomeworkGrades.SelectAsync(hg => hg.Id == id && !hg.IsDeleted);
        if (homeworkGrade is null)
            throw new NotFoundException($"Homework Grade with ID={id} is not found or was deleted");

        await unitOfWork.HomeworkGrades.UpdateAsync(homeworkGrade);
        await unitOfWork.SaveAsync();
        return await Task.FromResult(mapper.Map<HomeworkGradeViewModel>(homeworkGrade));
    }
}
