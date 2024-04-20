using HaadCRM.Service.DTOs.GroupDTOs.GroupStudents;

namespace HaadCRM.Service.Services.GroupStudents;

public class GroupStudent : IGroupStudent
{
    public ValueTask<GroupStudentViewModel> CreateAsync(GroupStudentCreateModel groupStudent)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<IEnumerable<GroupStudentViewModel>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<GroupStudentViewModel> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<GroupStudentViewModel> UpdateAsync(long id, GroupStudentUpdateModel groupStudent)
    {
        throw new NotImplementedException();
    }
}