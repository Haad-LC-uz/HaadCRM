using HaadCRM.Service.DTOs.HomeworkDTOs.HomeworkGrades;

namespace HaadCRM.Service.Services.HomeworkGrades;

public interface IHomeworkGradeService
{
    ValueTask<HomeworkGradeViewModel> CreateAsync(HomeworkGradeCreateModel createModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<HomeworkGradeViewModel>> GetAllAsync();
    ValueTask<HomeworkGradeViewModel> GetByIdAsync(long id);
    ValueTask<HomeworkGradeViewModel> UpdateAsync(long id, HomeworkGradeUpdateModel updateModel);
}
