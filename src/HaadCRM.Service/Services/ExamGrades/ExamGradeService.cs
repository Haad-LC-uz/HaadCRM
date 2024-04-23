using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Service.Exceptions;
using HaadCRM.Domain.Entities.Exams;
using HaadCRM.Service.DTOs.ExamDTOs.ExamGrades;

namespace HaadCRM.Service.Services.ExamGrades;

public class ExamGradeService(IUnitOfWork unitOfWork, IMapper mapper) : IExamGradeService
{
    public async ValueTask<ExamGradeViewModel> CreateAsync(ExamGradeCreateModel createModel)
    {
        var existExamGrade = await unitOfWork.ExamGrades.SelectAsync(eg =>
            eg.ExamId == createModel.ExamId && eg.StudentId == createModel.StudentId);

        if (existExamGrade is not null)
            throw new AlreadyExistException($"ExamGrade to student with ID={createModel.StudentId} already exists");

        var examGrade = mapper.Map<ExamGrade>(createModel);

        await unitOfWork.ExamGrades.InsertAsync(examGrade);
        await unitOfWork.SaveAsync();

        return mapper.Map<ExamGradeViewModel>(examGrade);
    }

    public async ValueTask<ExamGradeViewModel> GetByIdAsync(long id)
    {
        var examGrade = await unitOfWork.ExamGrades.SelectAsync(eg => eg.Id == id)
                        ?? throw new NotFoundException($"ExamGrade with ID={id} is not found");

        return mapper.Map<ExamGradeViewModel>(examGrade);
    }

    public async ValueTask<IEnumerable<ExamGradeViewModel>> GetAllAsync()
    {
        var examGrades = await unitOfWork.ExamGrades.SelectAsEnumerableAsync(
            expression: eg => !eg.IsDeleted,
            includes: ["Student", "Exam", "Employee"]);

        return mapper.Map<IEnumerable<ExamGradeViewModel>>(examGrades);
    }

    public async ValueTask<ExamGradeViewModel> UpdateAsync(long id, ExamGradeUpdateModel updateModel)
    {
        var existExamGrade = await unitOfWork.ExamGrades.SelectAsync(eg => eg.Id == id)
                      ?? throw new NotFoundException($"ExamGrade with ID={id} is not found");
        mapper.Map(updateModel, existExamGrade);

        await unitOfWork.ExamGrades.UpdateAsync(existExamGrade);
        await unitOfWork.SaveAsync();

        return await Task.FromResult(mapper.Map<ExamGradeViewModel>(existExamGrade));
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var exisExamGrade = await unitOfWork.ExamGrades.SelectAsync(eg => eg.Id == id)
                    ?? throw new NotFoundException($"ExamGrade with ID={id} is not found");

        await unitOfWork.ExamGrades.DeleteAsync(exisExamGrade);
        await unitOfWork.SaveAsync();

        return true;
    }
}