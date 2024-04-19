using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Groups;
using HaadCRM.Service.DTOs.GroupDTOs.Groups;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.GroupService;

public class GroupService(IMapper mapper, IUnitOfWork unitOfWork) : IGroupService
{
    public async ValueTask<GroupViewModel> CreateAsync(GroupCreateModel group)
    {
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

    public async ValueTask<IEnumerable<GroupViewModel>> GetAllAsync()
    {
        var Groups = await unitOfWork.Groups.SelectAsEnumerableAsync(
            expression: g => !g.IsDeleted);

        return mapper.Map<IEnumerable<GroupViewModel>>(Groups);
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