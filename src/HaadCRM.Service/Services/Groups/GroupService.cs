﻿using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Groups;
using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.GroupDTOs.Groups;
using HaadCRM.Service.Exceptions;
using HaadCRM.Service.Extensions;
using HaadCRM.Service.Validators.Exams.ExamGrades;
using HaadCRM.Service.Validators.Groups.Groups;
using Microsoft.EntityFrameworkCore;

namespace HaadCRM.Service.Services.GroupService;

public class GroupService(
    IMapper mapper, 
    IUnitOfWork unitOfWork,
    GroupCreateModelValidator createModelValidator,
    GroupUpdateModelValidator updateModelValidator) : IGroupService
{
    public async ValueTask<GroupViewModel> CreateAsync(GroupCreateModel group)
    {
        await createModelValidator.ValidateOrPanicAsync(group);
        var existCourse = await unitOfWork.Courses.SelectAsync(
            expression: c => c.Id == group.CourseId && !c.IsDeleted)
            ?? throw new NotFoundException($"Course with Id = {group.CourseId} is not found");

        var existTeacher = await unitOfWork.Users.SelectAsync(
            expression: t => t.Id == group.TeacherId && !t.IsDeleted)
            ?? throw new NotFoundException($"Teacher with Id = {group.TeacherId} is not found");

        var existAssistant = await unitOfWork.Users.SelectAsync(
            expression: t => t.Id == group.AssistantId && !t.IsDeleted)
            ?? throw new NotFoundException($"Assistant with Id = {group.TeacherId} is not found");

        var existGroup = await unitOfWork.Groups.SelectAsync(
            expression: g => g.Name == group.Name && !g.IsDeleted);

        if (existGroup is not null)
            throw new AlreadyExistException($"Group with Name = {group.Name} is already exists");

        var created = await unitOfWork.Groups.InsertAsync(mapper.Map<Group>(group));
        await unitOfWork.SaveAsync();

        return mapper.Map<GroupViewModel>(created);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existGroup = await unitOfWork.Groups.SelectAsync(
            expression: g => g.Id == id && !g.IsDeleted)
            ?? throw new NotFoundException($"Group with Id = {id} is not found");

        await unitOfWork.Groups.DeleteAsync(existGroup);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<GroupViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var Groups = unitOfWork.Groups.SelectAsQueryable(
            expression: g => !g.IsDeleted,
            isTracked: false).OrderBy(filter);

        return mapper.Map<IEnumerable<GroupViewModel>>(Groups.ToPaginateAsQueryable(@params).ToListAsync());
    }

    public async ValueTask<GroupViewModel> GetByIdAsync(long id)
    {
        var existGroup = await unitOfWork.Groups.SelectAsync(
           expression: g => g.Id == id && !g.IsDeleted)
           ?? throw new NotFoundException($"Group with Id = {id} is not found");

        return mapper.Map<GroupViewModel>(existGroup);
    }

    public async ValueTask<GroupViewModel> UpdateAsync(long id, GroupUpdateModel group)
    {
        await updateModelValidator.ValidateOrPanicAsync(group);
        var existCourse = await unitOfWork.Courses.SelectAsync(
           expression: c => c.Id == group.CourseId && !c.IsDeleted)
           ?? throw new NotFoundException($"Course with Id = {group.CourseId} is not found");

        var existTeacher = await unitOfWork.Users.SelectAsync(
            expression: t => (t.UserRole.Name.ToLower() == ("Teacher").ToLower()) && t.Id == group.TeacherId && !t.IsDeleted)
            ?? throw new NotFoundException($"Teacher with Id = {group.TeacherId} is not found");

        var existAssistant = await unitOfWork.Users.SelectAsync(
            expression: t => (t.UserRole.Name.ToLower() == ("Assistant").ToLower()) && t.Id == group.AssistantId && !t.IsDeleted)
            ?? throw new NotFoundException($"Assistant with Id = {group.TeacherId} is not found");

        var existGroup = await unitOfWork.Groups.SelectAsync(
           expression: g => g.Id == id && !g.IsDeleted)
           ?? throw new NotFoundException($"Group with Id = {id} is not found");

        var mapped = mapper.Map(group, existGroup);
        var updated = await unitOfWork.Groups.UpdateAsync(mapped);
        await unitOfWork.SaveAsync();

        return mapper.Map<GroupViewModel>(updated);
    }
}