using HaadCRM.Service.DTOs.ExamDTOs.Exams;

namespace HaadCRM.Service.Services.Exams.Exams;

public interface IExamService
{
    ValueTask<ExamViewModel> CreateAsync(ExamCreateModel exam);
    ValueTask<ExamViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<ExamViewModel>> GetAllAsync();
    ValueTask<ExamViewModel> UpdateAsync(long id, ExamUpdateModel exam);
    ValueTask<bool> DeleteAsync(long id);
}