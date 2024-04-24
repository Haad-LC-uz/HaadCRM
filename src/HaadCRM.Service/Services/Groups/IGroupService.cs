using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.GroupDTOs.Groups;

namespace HaadCRM.Service.Services.GroupService;

public interface IGroupService
{
    /// <summary>
    /// Creates new group
    /// </summary>
    /// <param name="group"></param>
    /// <returns></returns>
    ValueTask<GroupViewModel> CreateAsync(GroupCreateModel group);
    /// <summary>
    /// Updates already exist group
    /// </summary>
    /// <param name="id"></param>
    /// <param name="group"></param>
    /// <returns></returns>
    ValueTask<GroupViewModel> UpdateAsync(long id, GroupUpdateModel group);
    /// <summary>
    /// Deletes already exist group
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<bool> DeleteAsync(long id);
    /// <summary>
    /// Gets group by Id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    ValueTask<GroupViewModel> GetByIdAsync(long id);
    /// <summary>
    /// Will get all groups and returns IEnumerable
    /// </summary>
    /// <returns></returns>
    ValueTask<IEnumerable<GroupViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
}
