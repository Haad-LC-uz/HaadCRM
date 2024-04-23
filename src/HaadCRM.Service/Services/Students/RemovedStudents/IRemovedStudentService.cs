using HaadCRM.Service.DTOs.StudentDTOs.RemovedStudents;

namespace HaadCRM.Service.Services.Students.RemovedStudents;

public interface IRemovedStudentService
{
    ValueTask<RemovedStudentViewModel> CreateAsync(RemovedStudentCreateModel createModel);
    ValueTask<RemovedStudentViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<RemovedStudentViewModel>> GetAllAsync();
    ValueTask<RemovedStudentViewModel> UpdateAsync(long id, RemovedStudentUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
}