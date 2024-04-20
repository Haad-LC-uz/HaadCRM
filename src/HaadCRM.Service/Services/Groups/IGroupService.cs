﻿using HaadCRM.Service.DTOs.GroupDTOs.Groups;

namespace HaadCRM.Service.Services.GroupService;

public interface IGroupService
{
    ValueTask<GroupViewModel> CreateAsync(GroupCreateModel group);
    ValueTask<GroupViewModel> UpdateAsync(long id, GroupUpdateModel group);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<GroupViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<GroupViewModel>> GetAllAsync();
}