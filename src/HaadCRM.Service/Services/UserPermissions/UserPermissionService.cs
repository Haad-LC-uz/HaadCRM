﻿using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Users;
using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.UserDTOs.UserPermissions;
using HaadCRM.Service.Exceptions;
using HaadCRM.Service.Extensions;
using HaadCRM.Service.Validators.Users.Permissions;
using HaadCRM.Service.Validators.Users.UserPermissions;
using Microsoft.EntityFrameworkCore;

namespace HaadCRM.Service.Services.UserPermissions;

public class UserPermissionService(
    IMapper mapper, 
    IUnitOfWork unitOfWork,
    UserPermissionCreateModelValidator createModelValidator,
    UserPermissionUpdateModelValidator updateModelValidator) : IUserPermissionService
{

    // Creates a new user permission
    public async ValueTask<UserPermissionViewModel> CreateAsync(UserPermissionCreateModel createModel)
    {
        await createModelValidator.ValidateOrPanicAsync(createModel);

        // Check if a user permission with the same user ID and permission ID already exists
        var existingPermission = await unitOfWork.UserPermissions.SelectAsync(up =>
            up.UserId == createModel.UserId && up.PermissionId == createModel.PermissionId);

        if (existingPermission != null)
        {
            throw new AlreadyExistException("This user permission already exists.");
        }

        // Map the createModel to a UserPermission entity
        var userPermission = mapper.Map<UserPermission>(createModel);

        // Insert the new user permission into the database
        var createdUserPermission = await unitOfWork.UserPermissions.InsertAsync(userPermission);
        await unitOfWork.SaveAsync();

        // Map the created user permission back to a view model and return
        return mapper.Map<UserPermissionViewModel>(createdUserPermission);
    }

    // Updates an existing user permission
    public async ValueTask<UserPermissionViewModel> UpdateAsync(UserPermissionUpdateModel updateModel)
    {
        await updateModelValidator.ValidateOrPanicAsync(updateModel);

        // Find the user permission by user ID and permission ID, throw NotFoundException if not found
        var userPermission = await unitOfWork.UserPermissions.SelectAsync(up =>
            up.UserId == updateModel.UserId && up.PermissionId == updateModel.PermissionId)
            ?? throw new NotFoundException("User permission not found.");

        // Map properties from updateModel to the retrieved user permission entity
        mapper.Map(updateModel, userPermission);

        // Update the user permission in the database
        await unitOfWork.UserPermissions.UpdateAsync(userPermission);
        await unitOfWork.SaveAsync();

        // Map the updated user permission back to a view model and return
        return mapper.Map<UserPermissionViewModel>(userPermission);
    }

    // Deletes a user permission by ID
    public async ValueTask<bool> DeleteAsync(long id)
    {
        // Find the user permission by ID and ensure it's not already deleted, throw NotFoundException if not found
        var userPermission = await unitOfWork.UserPermissions.SelectAsync(up =>
            up.Id == id && !up.IsDeleted)
            ?? throw new NotFoundException("User permission not found.");

        // Delete the user permission from the database
        await unitOfWork.UserPermissions.DeleteAsync(userPermission);
        await unitOfWork.SaveAsync();

        return true; // Deletion successful
    }

    // Gets all user permissions
    public async ValueTask<IEnumerable<UserPermissionViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        // Retrieve all user permissions from the database
        var userPermissions = unitOfWork.UserPermissions.SelectAsQueryable(
            expression: up => up.IsDeleted, 
            isTracked: false).OrderBy(filter);

        // Map the list of user permissions to a list of view models and return
        return mapper.Map<IEnumerable<UserPermissionViewModel>>(userPermissions.ToPaginateAsQueryable(@params).ToListAsync());
    }

    // Gets a user permission by user ID and permission ID
    public async ValueTask<UserPermissionViewModel> GetByIdAsync(long id)
    {
        var existPermission = await unitOfWork.UserPermissions.SelectAsync(p => p.Id == id && !p.IsDeleted)
                ?? throw new NotFoundException($"User permission not found with ID = {id}");

        return mapper.Map<UserPermissionViewModel>(existPermission);
    }
}
