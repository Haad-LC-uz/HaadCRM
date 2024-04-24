using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.HomeworkDTOs.Homework;

namespace HaadCRM.Service.Services.HomeworkServices;

public interface IHomeWorkService
{
    ValueTask<HomeworkViewModel> CreateAsync(HomeworkCreateModel createModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<HomeworkViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<HomeworkViewModel> GetByIdAsync(long id);
    ValueTask<HomeworkViewModel> UpdateAsync(long id, HomeworkUpdateModel updateModel);
}
