using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Homeworks;
using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.HomeworkDTOs.HomeworkGrades;
using HaadCRM.Service.Exceptions;
using HaadCRM.Service.Extensions;
using HaadCRM.Service.Validators.Exams.ExamGrades;
using HaadCRM.Service.Validators.Homework.HomeworkFiles;
using HaadCRM.Service.Validators.Homework.HomeworkGrades;
using Microsoft.EntityFrameworkCore;

namespace HaadCRM.Service.Services.HomeworkGrades;

public class HomeworkGradeService(
    IUnitOfWork unitOfWork, 
    IMapper mapper,
    HomeworkGradeCreateModelValidator createModelValidator,
    HomeworkGradeUpdateModelValidator updateModelValidator) : IHomeworkGradeService
{
    public async ValueTask<HomeworkGradeViewModel> CreateAsync(HomeworkGradeCreateModel createModel)
    {
        await createModelValidator.ValidateOrPanicAsync(createModel);
        var homeworkGrade = await unitOfWork.HomeworkGrades.SelectAsync(hg =>
        hg.HomeworkId == createModel.HomeworkId
        && hg.AssistantId == createModel.AssistantId
        && hg.StudentId == createModel.StudentId);

        if (homeworkGrade != null)
            throw new NotFoundException("Something is wrong! Try enter correctly ID");

        await unitOfWork.HomeworkGrades.InsertAsync(mapper.Map<HomeworkGrade>(createModel));
        await unitOfWork.SaveAsync();

        return await Task.FromResult(mapper.Map<HomeworkGradeViewModel>(createModel));
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var homeworkGrade = await unitOfWork.HomeworkGrades.SelectAsync(hg => hg.Id == id && !hg.IsDeleted);
        if (homeworkGrade == null)
            throw new NotFoundException($"HomeworkGrade with ID={id} is not found");

        await unitOfWork.HomeworkGrades.DeleteAsync(homeworkGrade);
        await unitOfWork.SaveAsync();

        return await Task.FromResult(true);
    }

    public async ValueTask<IEnumerable<HomeworkGradeViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var homeworkGrades = unitOfWork.HomeworkGrades.SelectAsQueryable(
            expression: hg => !hg.IsDeleted,
            includes: ["Homework", "Student", "Assistant"],
            isTracked: false).OrderBy(filter);

        return mapper.Map<IEnumerable<HomeworkGradeViewModel>>(homeworkGrades.ToPaginateAsQueryable(@params).ToListAsync());
    }

    public async ValueTask<HomeworkGradeViewModel> GetByIdAsync(long id)
    {
        var homeworkGrade = await unitOfWork.HomeworkGrades.SelectAsync(hg => hg.Id == id && !hg.IsDeleted);
        if (homeworkGrade == null)
            throw new NotFoundException($"Homework Grade with ID={id} is not FOUND");

        return mapper.Map<HomeworkGradeViewModel>(homeworkGrade);
    }

    public async ValueTask<HomeworkGradeViewModel> UpdateAsync(long id, HomeworkGradeUpdateModel updateModel)
    {
        await updateModelValidator.ValidateOrPanicAsync(updateModel);
        var homeworkGrade = await unitOfWork.HomeworkGrades.SelectAsync(hg => hg.Id == id && !hg.IsDeleted)
            ?? throw new NotFoundException($"Homework Grade with ID={id} is not found or was deleted");
        await unitOfWork.HomeworkGrades.UpdateAsync(homeworkGrade);
        await unitOfWork.SaveAsync();
        return await Task.FromResult(mapper.Map<HomeworkGradeViewModel>(homeworkGrade));
    }
}
