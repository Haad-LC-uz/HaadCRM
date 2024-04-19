using HaadCRM.Service.DTOs.HomeworkDTOs.HomeworkGrades;

namespace HaadCRM.Service.Services.Homeworks.HomeworkGrades;

public interface IHomeworkGradeService
{
    ValueTask<HomeWorkGradeViewModel> CreateAsync(HomeworkGradeCreateModel createModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<HomeWorkGradeViewModel>> GetAllAsync();
    ValueTask<HomeWorkGradeViewModel> GetByIdAsync(long id);
    ValueTask<HomeWorkGradeViewModel> UpdateAsync(long id, HomeworkGradeUpdateModel updateModel);
}
