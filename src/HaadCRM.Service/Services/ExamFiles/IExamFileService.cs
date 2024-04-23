using HaadCRM.Service.DTOs.ExamDTOs.ExamFiles;

namespace HaadCRM.Service.Services.ExamFiles;

public interface IExamFileService
{
    ValueTask<ExamFileViewModel> CreateAsync(ExamFileCreateModel createModel);
    ValueTask<ExamFileViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<ExamFileViewModel>> GetAllAsync();
    ValueTask<ExamFileViewModel> UpdateAsync(long id, ExamFileUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
}