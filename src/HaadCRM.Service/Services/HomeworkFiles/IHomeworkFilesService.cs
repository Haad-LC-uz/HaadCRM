using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.HomeworkDTOs.HomeworkFiles;

namespace HaadCRM.Service.Services.HomeworkFiles;

public interface IHomeworkFilesService
{
    ValueTask<HomeworkFileViewModel> CreateAsync(HomeworkFileCreateModel createModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<HomeworkFileViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<HomeworkFileViewModel> GetByIdAsync(long id);
    ValueTask<HomeworkFileViewModel> UpdateAsync(long id, HomeworkFileUpdateModel updateModel);
}
