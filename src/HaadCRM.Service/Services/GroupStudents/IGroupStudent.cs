using HaadCRM.Service.DTOs.GroupDTOs.GroupStudents;

namespace HaadCRM.Service.Services.GroupStudents;

public interface IGroupStudent
{
    ValueTask<GroupStudentViewModel> CreateAsync(GroupStudentCreateModel groupStudent);
    ValueTask<GroupStudentViewModel> UpdateAsync(long id, GroupStudentUpdateModel groupStudent);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<GroupStudentViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<GroupStudentViewModel>> GetAllAsync();
}
