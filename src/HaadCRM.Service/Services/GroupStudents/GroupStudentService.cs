using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Groups;
using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.GroupDTOs.GroupStudents;
using HaadCRM.Service.Exceptions;
using HaadCRM.Service.Extensions;
using HaadCRM.Service.Validators.Exams.ExamGrades;
using HaadCRM.Service.Validators.Groups.GroupStudents;

namespace HaadCRM.Service.Services.GroupStudents;

public class GroupStudentService(
    IMapper mapper, 
    IUnitOfWork unitOfWork,
    GroupStudentCreateModelValidator createModelValidator,
    GroupStudentUpdateModelValidator updateModelValidator) : IGroupStudentService
{
    public async ValueTask<GroupStudentViewModel> CreateAsync(GroupStudentCreateModel groupStudent)
    {
        await createModelValidator.ValidateOrPanicAsync(groupStudent);
        var existGroup = await unitOfWork.Groups.SelectAsync(
            expression: g => g.Id == groupStudent.GroupId && !g.IsDeleted)
            ?? throw new NotFoundException($"Group with Id = {groupStudent.GroupId} is not found");

        var existStudent = await unitOfWork.Students.SelectAsync(
            expression: s => s.Id == groupStudent.StudentId && !s.IsDeleted)
            ?? throw new NotFoundException($"Student with Id = {groupStudent.StudentId} is not found");

        var existGroupStudent = await unitOfWork.GroupStudents.SelectAsync(
            expression: gs => gs.GroupId == groupStudent.GroupId && gs.StudentId == groupStudent.StudentId && !gs.IsDeleted);

        if (existGroupStudent is not null)
            throw new AlreadyExistException($"GroupStudent with GroupId = {groupStudent.GroupId} and StudentId = {groupStudent.StudentId} is already exists");

        var created = await unitOfWork.GroupStudents.InsertAsync(mapper.Map<GroupStudent>(groupStudent));
        await unitOfWork.SaveAsync();

        return mapper.Map<GroupStudentViewModel>(created);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existGroupStudent = await unitOfWork.GroupStudents.SelectAsync(
            expression: gs => gs.Id == id && !gs.IsDeleted)
            ?? throw new NotFoundException($"GroupStudent with Id = {id} is not found");

        await unitOfWork.GroupStudents.DeleteAsync(existGroupStudent);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<GroupStudentViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var GroupStudents = unitOfWork.GroupStudents.SelectAsQueryable(
            expression: gss => !gss.IsDeleted,
            isTracked: false);

        return mapper.Map<IEnumerable<GroupStudentViewModel>>(GroupStudents);
    }

    public async ValueTask<GroupStudentViewModel> GetByIdAsync(long id)
    {
        var existGroupStudent = await unitOfWork.GroupStudents.SelectAsync(
            expression: gs => gs.Id == id && !gs.IsDeleted)
            ?? throw new NotFoundException($"GroupStudent with Id = {id} is not found");

        return mapper.Map<GroupStudentViewModel>(existGroupStudent);
    }

    public async ValueTask<GroupStudentViewModel> UpdateAsync(long id, GroupStudentUpdateModel groupStudent)
    {
        await updateModelValidator.ValidateOrPanicAsync(groupStudent);
        var existGroup = await unitOfWork.Groups.SelectAsync(
            expression: g => g.Id == groupStudent.GroupId && !g.IsDeleted)
            ?? throw new NotFoundException($"Group with Id = {groupStudent.GroupId} is not found");

        var existStudent = await unitOfWork.Students.SelectAsync(
            expression: s => s.Id == groupStudent.StudentId && !s.IsDeleted)
            ?? throw new NotFoundException($"Student with Id = {groupStudent.StudentId} is not found");

        var existGroupStudent = await unitOfWork.GroupStudents.SelectAsync(
           expression: gs => gs.Id == id && !gs.IsDeleted)
           ?? throw new NotFoundException($"GroupStudent with Id = {id} is not found");

        var mapped = mapper.Map(groupStudent, existGroupStudent);
        var updated = await unitOfWork.GroupStudents.UpdateAsync(mapped);
        await unitOfWork.SaveAsync();

        return mapper.Map<GroupStudentViewModel>(updated);
    }
}