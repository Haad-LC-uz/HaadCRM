using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Users;
using HaadCRM.Service.DTOs.UserDTOs.Permissions;
using HaadCRM.Service.Exceptions;
using HaadCRM.Service.Extensions;
using HaadCRM.Service.Validators.Lessons.Lessons;
using HaadCRM.Service.Validators.Users.Permissions;
using HaadCRM.Service.Validators.Users.UserPermissions;

namespace HaadCRM.Service.Services.Permissions;

public class PermissionService(
    IUnitOfWork unitOfWork, 
    IMapper mapper,
    PermissionCreateModelValidator createModelValidator,
    PermissionUpdateModelValidator updateModelValidator) : IPermissionService
{

    // Creates a new permission
    public async ValueTask<PermissionViewModel> CreateAsync(PermissionCreateModel createModel)
    {
        await createModelValidator.ValidateOrPanicAsync(createModel);
        // Check if a permission with the same method already exists
        var existPermission = await unitOfWork.Permissions.SelectAsync(permission => permission.Method == createModel.Method);
        if (existPermission != null)
        {
            throw new AlreadyExistException($"This permission already exists with method={createModel.Method}");
        }

        // Map the createModel to a Permission entity
        var permission = mapper.Map<Permission>(createModel);

        // Insert the new permission into the database
        var createdPermission = await unitOfWork.Permissions.InsertAsync(permission);
        await unitOfWork.SaveAsync();

        // Map the created permission back to a view model and return
        return mapper.Map<PermissionViewModel>(createdPermission);
    }

    // Updates an existing permission
    public async ValueTask<PermissionViewModel> UpdateAsync(long id, PermissionUpdateModel updateModel)
    {
        await updateModelValidator.ValidateOrPanicAsync(updateModel);
        // Find the permission by ID, throw NotFoundException if not found
        var permission = await unitOfWork.Permissions.SelectAsync(permission => permission.Id == id)
           ?? throw new NotFoundException($"Permission is not found with this ID={id}");

        // Map properties from updateModel to the retrieved permission entity
        mapper.Map(updateModel, permission);

        // Update the permission in the database
        await unitOfWork.Permissions.UpdateAsync(permission);
        await unitOfWork.SaveAsync();

        // Map the updated permission back to a view model and return
        return mapper.Map<PermissionViewModel>(permission);
    }

    // Deletes a permission by ID
    public async ValueTask<bool> DeleteAsync(long id)
    {
        // Find the permission by ID, throw NotFoundException if not found
        var permission = await unitOfWork.Permissions.SelectAsync(permission => permission.Id == id)
           ?? throw new NotFoundException($"Permission is not found with this ID={id}");

        // Delete the permission from the database
        await unitOfWork.Permissions.DeleteAsync(permission);
        await unitOfWork.SaveAsync();

        return true; // Deletion successful
    }

    // Gets all permissions
    public async ValueTask<IEnumerable<PermissionViewModel>> GetAllAsync()
    {
        // Retrieve all permissions from the database
        var permissions = await unitOfWork.Permissions.SelectAsEnumerableAsync();

        // Map the list of permissions to a list of view models and return
        return mapper.Map<IEnumerable<PermissionViewModel>>(permissions);
    }

    // Gets a permission by ID
    public async ValueTask<PermissionViewModel> GetByIdAsync(long id)
    {
        // Find the permission by ID, throw NotFoundException if not found
        var permission = await unitOfWork.Permissions.SelectAsync(permission => permission.Id == id)
           ?? throw new NotFoundException($"Permission is not found with this ID={id}");

        // Map the retrieved permission to a view model and return
        return mapper.Map<PermissionViewModel>(permission);
    }
}
