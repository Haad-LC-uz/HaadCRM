using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Exams;
using HaadCRM.Service.DTOs.ExamDTOs.Exams;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.Exams.Exams;

public class ExamService(IUnitOfWork unitOfWork, IMapper mapper) : IExamService
{
    public async ValueTask<ExamViewModel> CreateAsync(ExamCreateModel createModel)
    {
        var existExam = await unitOfWork.Exams.SelectAsync(e =>
            (e.AssistantId == createModel.AssistantId || e.TeacherId == createModel.TeacherId) && e.DateOfExam == createModel.DateOfExam);

        if (existExam != null)
            throw new AlreadyExistException("Exam at this time with these teachers already exists");

        await unitOfWork.Exams.InsertAsync(mapper.Map<Exam>(createModel));
        await unitOfWork.SaveAsync();

        return mapper.Map<ExamViewModel>(createModel);
    }

    public async ValueTask<ExamViewModel> GetByIdAsync(long id)
    {
        var exam = await unitOfWork.Exams.SelectAsync(exam => exam.Id == id && !exam.IsDeleted);
        if (exam == null)
            throw new NotFoundException($"Homework with ID={id} is not found or was deleted");

        return await Task.FromResult(mapper.Map<ExamViewModel>(exam));
    }

    public async ValueTask<IEnumerable<ExamViewModel>> GetAllAsync()
    {
        var exams = await unitOfWork.Exams.SelectAsEnumerableAsync(
            expression: exam => !exam.IsDeleted,
            includes: ["Employee", "Group", "Asset"]);

        return mapper.Map<IEnumerable<ExamViewModel>>(exams);
    }

    public async ValueTask<ExamViewModel> UpdateAsync(long id, ExamUpdateModel updateModel)
    {
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