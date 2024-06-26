﻿using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Users;
using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.UserDTOs.UserRoles;
using HaadCRM.Service.Exceptions;
using HaadCRM.Service.Extensions;
using HaadCRM.Service.Validators.Users.Permissions;
using HaadCRM.Service.Validators.Users.UserRoles;
using Microsoft.EntityFrameworkCore;

namespace HaadCRM.Service.Services.UserRoles;

public class UserRoleService(
    IUnitOfWork unitOfWork, 
    IMapper mapper,
    UserRoleCreateModelValidator createModelValidator,
    UserRoleUpdateModelValidator updateModelValidator) : IUserRoleService
{

    // Creates a new user role
    public async ValueTask<UserRoleViewModel> CreateAsync(UserRoleCreateModel createModel)
    {
        await createModelValidator.ValidateOrPanicAsync(createModel);

        // Check if a role with the same name already exists
        var existingRole = await unitOfWork.UserRoles.SelectAsync(role => role.Name == createModel.Name);

        if (existingRole != null)
        {
            throw new AlreadyExistException("A role with the same name already exists.");
        }

        // Map the createModel to a UserRole entity
        var userRole = mapper.Map<UserRole>(createModel);

        // Insert the new user role into the database
        var createdUserRole = await unitOfWork.UserRoles.InsertAsync(userRole);
        await unitOfWork.SaveAsync();

        // Map the created user role back to a view model and return
        return mapper.Map<UserRoleViewModel>(createdUserRole);
    }

    // Deletes a user role by ID
    public async ValueTask<bool> DeleteAsync(long id)
    {
        // Find the user role by ID, throw NotFoundException if not found
        var userRole = await unitOfWork.UserRoles.SelectAsync(role => role.Id == id)
            ?? throw new NotFoundException($"UserRole is not found with this ID={id}");

        // Delete the user role from the database
        await unitOfWork.UserRoles.DeleteAsync(userRole);
        await unitOfWork.SaveAsync();

        return true; // Deletion successful
    }

    // Gets all user roles
    public async ValueTask<IEnumerable<UserRoleViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        // Retrieve all user roles from the database
        var userRoles = unitOfWork.UserRoles.SelectAsQueryable(
            expression: ur => ur.IsDeleted,
            isTracked: false)
            .OrderBy(filter);

        // Map the list of user roles to a list of view models and return
        return await Task.FromResult(mapper.Map<IEnumerable<UserRoleViewModel>>(userRoles.ToPaginateAsQueryable(@params)));
    }

    // Gets a user role by ID
    public async ValueTask<UserRoleViewModel> GetByIdAsync(long id)
    {
        // Find the user role by ID, throw NotFoundException if not found
        var userRole = await unitOfWork.UserRoles.SelectAsync(role => role.Id == id)
            ?? throw new NotFoundException($"UserRole is not found with this ID={id}");

        // Map the retrieved user role to a view model and return
        return mapper.Map<UserRoleViewModel>(userRole);
    }

    // Updates an existing user role by ID with the provided updateModel
    public async ValueTask<UserRoleViewModel> UpdateAsync(long id, UserRoleUpdateModel updateModel)
    {
        await updateModelValidator.ValidateOrPanicAsync(updateModel);

        // Find the user role by ID, throw NotFoundException if not found
        var userRole = await unitOfWork.UserRoles.SelectAsync(role => role.Id == id)
            ?? throw new NotFoundException($"UserRole is not found with this ID={id}");

        // Map properties from updateModel to the retrieved user role entity
        mapper.Map(updateModel, userRole);

        // Update the user role in the database
        await unitOfWork.UserRoles.UpdateAsync(userRole);
        await unitOfWork.SaveAsync();

        // Map the updated user role back to a view model and return
        return mapper.Map<UserRoleViewModel>(userRole);
    }
}
