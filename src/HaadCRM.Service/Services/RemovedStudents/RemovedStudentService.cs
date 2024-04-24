using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Students;
using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.StudentDTOs.RemovedStudents;
using HaadCRM.Service.Exceptions;
using HaadCRM.Service.Extensions;
using HaadCRM.Service.Validators.Lessons.Lessons;
using HaadCRM.Service.Validators.Students.RemovedStudents;

namespace HaadCRM.Service.Services.RemovedStudents;

public class RemovedStudentService(
    IUnitOfWork unitOfWork, 
    IMapper mapper,
    RemovedStudentCreateModelValidator createModelValidator,
    RemovedStudentUpdateModelValidator updateModelValidator) : IRemovedStudentService
{
    public async ValueTask<RemovedStudentViewModel> CreateAsync(RemovedStudentCreateModel createModel)
    {
        await createModelValidator.ValidateOrPanicAsync(createModel);

        var removedStudent = await unitOfWork.RemovedStudents.SelectAsync(rs => rs.StudentId == createModel.StudentId);

        if (removedStudent is not null)
            throw new AlreadyExistException($"Student with ID={createModel.StudentId} is already removed");

        await unitOfWork.RemovedStudents.InsertAsync(mapper.Map<RemovedStudent>(createModel));
        await unitOfWork.SaveAsync();
        return mapper.Map<RemovedStudentViewModel>(createModel);
    }

    public async ValueTask<RemovedStudentViewModel> GetByIdAsync(long id)
    {
        var removedStudent = await unitOfWork.RemovedStudents.SelectAsync(rs => rs.Id == id)
                      ?? throw new NotFoundException($"Removed student with ID={id} is not found");

        return mapper.Map<RemovedStudentViewModel>(removedStudent);
    }

    public async ValueTask<IEnumerable<RemovedStudentViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var removedStudents = unitOfWork.RemovedStudents.SelectAsQueryable(
            expression: rs => !rs.IsDeleted,
            includes: ["Student", "Group"],
            isTracked: false);
        return mapper.Map<IEnumerable<RemovedStudentViewModel>>(removedStudents);
    }


    public async ValueTask<RemovedStudentViewModel> UpdateAsync(long id, RemovedStudentUpdateModel updateModel)
    {
        await updateModelValidator.ValidateOrPanicAsync(updateModel);

        var removedStudent = await unitOfWork.RemovedStudents.SelectAsync(rs => rs.Id == id)
                      ?? throw new NotFoundException($"Removed student with ID={id} is not found");
        mapper.Map(updateModel, removedStudent);

        await unitOfWork.RemovedStudents.UpdateAsync(removedStudent);
        await unitOfWork.SaveAsync();

        return mapper.Map<RemovedStudentViewModel>(removedStudent);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var removedStudent = await unitOfWork.RemovedStudents.SelectAsync(rs => rs.Id == id)
                    ?? throw new NotFoundException($"Removed student with ID={id} is not found");

        await unitOfWork.RemovedStudents.DeleteAsync(removedStudent);
        await unitOfWork.SaveAsync();
        return true;
    }
}