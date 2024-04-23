using HaadCRM.Service.DTOs.HomeworkDTOs.Homework;

namespace HaadCRM.Service.Services.Homework;

public interface IHomeWorkService
{
    ValueTask<HomeworkViewModel> CreateAsync(HomeworkCreateModel createModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<HomeworkViewModel>> GetAllAsync();
    ValueTask<HomeworkViewModel> GetByIdAsync(long id);
    ValueTask<HomeworkViewModel> UpdateAsync(long id, HomeworkUpdateModel updateModel);
}
