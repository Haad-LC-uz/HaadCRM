using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.ExamDTOs.ExamFiles;

namespace HaadCRM.Service.Services.ExamFiles;

public interface IExamFileService
{
    ValueTask<ExamFileViewModel> CreateAsync(ExamFileCreateModel createModel);
    ValueTask<ExamFileViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<ExamFileViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<ExamFileViewModel> UpdateAsync(long id, ExamFileUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
}