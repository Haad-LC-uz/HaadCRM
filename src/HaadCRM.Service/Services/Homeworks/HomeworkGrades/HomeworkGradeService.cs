using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Homeworks;
using HaadCRM.Service.DTOs.HomeworkDTOs.HomeworkGrades;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.Homeworks.HomeworkGrades;

public class HomeworkGradeService(IUnitOfWork unitOfWork, IMapper mapper) : IHomeworkGradeService
{
    public async ValueTask<HomeWorkGradeViewModel> CreateAsync(HomeworkGradeCreateModel createModel)
    {
        var homeworkGrade = await unitOfWork.HomeworkGrades.SelectAsync(hg =>
        hg.HomeworkId == createModel.HomeworkId
        && hg.AssistantId == createModel.AssistantId
        && hg.StudentId == createModel.StudentId);

        if (homeworkGrade is null)
            throw new NotFoundException("Something is wrong! Try enter correctly ID");

        await unitOfWork.HomeworkGrades.InsertAsync(mapper.Map<HomeworkGrade>(createModel));
        await unitOfWork.SaveAsync();

        return await Task.FromResult(mapper.Map<HomeWorkGradeViewModel>(createModel));
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

    public async ValueTask<IEnumerable<HomeWorkGradeViewModel>> GetAllAsync()
    {
        var homeworkGrades = await unitOfWork.HomeworkGrades.SelectAsEnumerableAsync(
            expression: hg => !hg.IsDeleted,
            includes: ["Homework", "Student", "Assistant"]);

        return mapper.Map<IEnumerable<HomeWorkGradeViewModel>>(homeworkGrades);
    }

    public async ValueTask<HomeWorkGradeViewModel> GetByIdAsync(long id)
    {
        var homeworkGrade = await unitOfWork.HomeworkGrades.SelectAsync(hg => hg.Id == id && !hg.IsDeleted);
        if (homeworkGrade == null)
            throw new NotFoundException($"Homework Grade with ID={id} is not FOUND");

        return mapper.Map<HomeWorkGradeViewModel>(homeworkGrade);
    }

    public async ValueTask<HomeWorkGradeViewModel> UpdateAsync(long id, HomeworkGradeUpdateModel updateModel)
    {
        var homeworkGrade = await unitOfWork.HomeworkGrades.SelectAsync(hg => hg.Id == id && !hg.IsDeleted);
        if (homeworkGrade == null)
            throw new NotFoundException($"Homework Grade with ID={id} is not found or was deleted");

        await unitOfWork.HomeworkGrades.UpdateAsync(homeworkGrade);
        await unitOfWork.SaveAsync();
        return await Task.FromResult(mapper.Map<HomeWorkGradeViewModel>(homeworkGrade));
    }
}
