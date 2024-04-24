using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.StudentDTOs.Students;

namespace HaadCRM.Service.Services.Students.Students;

public interface IStudentService
{
    ValueTask<StudentViewModel> CreateAsync(StudentCreateModel createModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<IEnumerable<StudentViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<StudentViewModel> GetByIdAsync(long id);
    ValueTask<StudentViewModel> UpdateAsync(long id, StudentUpdateModel updateModel);
}
