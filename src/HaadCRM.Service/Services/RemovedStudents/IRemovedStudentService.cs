using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.StudentDTOs.RemovedStudents;

namespace HaadCRM.Service.Services.RemovedStudents;

public interface IRemovedStudentService
{
    ValueTask<RemovedStudentViewModel> CreateAsync(RemovedStudentCreateModel createModel);
    ValueTask<RemovedStudentViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<RemovedStudentViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<RemovedStudentViewModel> UpdateAsync(long id, RemovedStudentUpdateModel updateModel);
    ValueTask<bool> DeleteAsync(long id);
}