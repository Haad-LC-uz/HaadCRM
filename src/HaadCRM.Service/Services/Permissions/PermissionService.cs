using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Users;
using HaadCRM.Service.DTOs.UserDTOs.Permissions;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.Permissions;

public class PermissionService(IUnitOfWork unitOfWork, IMapper mapper)
{
    public async ValueTask<PermissionViewModel> CreateAsync(PermissionCreateModel createModel)
    {
        var existPermission = await unitOfWork.Permissions.SelectAsync(permission => permission.Method == createModel.Method);
        if (existPermission != null)
        {
            throw new AlreadyExistException($"This permission is already exist with method={createModel.Method}");
        }

        var permission = mapper.Map<Permission>(createModel);

        var createdPermission = await unitOfWork.Permissions.InsertAsync(permission);

        await unitOfWork.SaveAsync();

        return mapper.Map<PermissionViewModel>(createdPermission);        
    }
    public async ValueTask<PermissionViewModel> UpdateAsync(long id, PermissionUpdateModel updateModel){
        var permission = await unitOfWork.Permissions.SelectAsync(permission => permission.Id == id)
           ?? throw new NotFoundException($"Permission is not found with this ID={id}");
        mapper.Map(updateModel, permission);

        await unitOfWork.Permissions.UpdateAsync(permission);

        await unitOfWork.SaveAsync();

        return mapper.Map<PermissionViewModel>(permission);
    }
    public async ValueTask<bool> DeleteAsync(long id)
    {
        var permission = await unitOfWork.Permissions.SelectAsync(permission => permission.Id == id)
           ?? throw new NotFoundException($"Permission is not found with this ID={id}");
        await unitOfWork.Permissions.DeleteAsync(permission);
        await unitOfWork.SaveAsync();
        
        return true;
    }
}
