using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Exams;
using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.ExamDTOs.Exams;
using HaadCRM.Service.Exceptions;
using HaadCRM.Service.Extensions;
using HaadCRM.Service.Validators.Exams.Exams;
using Microsoft.EntityFrameworkCore;

namespace HaadCRM.Service.Services.Exams.Exams;

public class ExamService(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    ExamCreateModelValidator createModelValidator,
    ExamUpdateModelValidator updateModelValidator) : IExamService
{
    public async ValueTask<ExamViewModel> CreateAsync(ExamCreateModel createModel)
    {
        await createModelValidator.ValidateOrPanicAsync(createModel);
        var existExam = await unitOfWork.Exams.SelectAsync(e =>
            (e.AssistantId == createModel.AssistantId || e.TeacherId == createModel.TeacherId) && e.DateOfExam == createModel.DateOfExam);

        if (existExam != null)
            throw new AlreadyExistException("Exam at this time with these teachers already exists");
        var mapped = mapper.Map<Exam>(createModel);
        var last = await unitOfWork.Exams.SelectAsEnumerableAsync();
        mapped.Id = last.Any() ? last.Last().Id + 1 : 1;
        await unitOfWork.Exams.InsertAsync(mapped);
        await unitOfWork.SaveAsync();

        return mapper.Map<ExamViewModel>(mapped);
    }

    public async ValueTask<ExamViewModel> GetByIdAsync(long id)
    {
        var exam = await unitOfWork.Exams.SelectAsync(
            exam => exam.Id == id && !exam.IsDeleted,
            ["Teacher", "Assistant", "Group", "ProfilePicture", "ExamFiles", "ExamGrades"]
            )
            ?? throw new NotFoundException($"Homework with ID={id} is not found or was deleted");
        return await Task.FromResult(mapper.Map<ExamViewModel>(exam));
    }

    public async ValueTask<IEnumerable<ExamViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var exams = unitOfWork.Exams.SelectAsQueryable(
            expression: exam => !exam.IsDeleted,
            includes: ["Teacher", "Assistant","Group", "ProfilePicture"],
            isTracked: false).OrderBy(filter);

        return await Task.FromResult(mapper.Map<IEnumerable<ExamViewModel>>(exams.ToPaginateAsQueryable(@params)));
    }

    public async ValueTask<ExamViewModel> UpdateAsync(long id, ExamUpdateModel updateModel)
    {
        await updateModelValidator.ValidateOrPanicAsync(updateModel);

        var exam = await unitOfWork.Exams.SelectAsync(e => e.Id == id && !e.IsDeleted)
                   ?? throw new NotFoundException($"exam with ID={id} is not found");

        mapper.Map(updateModel, exam);

        await unitOfWork.Exams.UpdateAsync(exam);
        await unitOfWork.SaveAsync();

        return await Task.FromResult(mapper.Map<ExamViewModel>(exam));
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var exam = await unitOfWork.Exams.SelectAsync(e => e.Id == id)
                   ?? throw new NotFoundException($"exam with ID={id} is not found");

        await unitOfWork.Exams.DeleteAsync(exam);
        await unitOfWork.SaveAsync();

        return true;
    }
}