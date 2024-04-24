using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.GroupDTOs.GroupStudents;

namespace HaadCRM.Service.Services.GroupStudents;

public interface IGroupStudentService
{
    /// <summary>
    /// Creates new groupStudent
    /// </summary>
    /// <param name="groupStudent"></param>
    /// <returns></returns>
    ValueTask<GroupStudentViewModel> CreateAsync(GroupStudentCreateModel groupStudent);
    /// <summary>
    /// Updates already exist groupStudent
    /// </summary>
    /// <param name="id"></param>
    /// <param name="groupStudent"></param>
    /// <returns></returns>
    ValueTask<GroupStudentViewModel> UpdateAsync(long id, GroupStudentUpdateModel groupStudent);
    /// <summary>
    /// Deletes already exist groupStudent
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<bool> DeleteAsync(long id);
    /// <summary>
    /// Gets groupStudent by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<GroupStudentViewModel> GetByIdAsync(long id);
    /// <summary>
    /// Will get all groupStudents and returns IEnumerable
    /// </summary>
    /// <returns></returns>
    ValueTask<IEnumerable<GroupStudentViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
