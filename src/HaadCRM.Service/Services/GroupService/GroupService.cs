using HaadCRM.Service.DTOs.GroupDTOs.Groups;

namespace HaadCRM.Service.Services.GroupService;

public class GroupService : IGroupService
{
    public ValueTask<GroupViewModel> CreateAsync(GroupCreateModel group)
    {
        throw new NotImplementedException();
    }

    public ValueTask<bool> DeleteAsync(GroupCreateModel group)
    {
        throw new NotImplementedException();
    }

    public ValueTask<GroupViewModel> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public ValueTask<GroupViewModel> GetByIdAsync(long id)
    {
        throw new NotImplementedException();
    }

    public ValueTask<GroupViewModel> UpdateAsync(long id, GroupUpdateModel group)
    {
        throw new NotImplementedException();
    }
}