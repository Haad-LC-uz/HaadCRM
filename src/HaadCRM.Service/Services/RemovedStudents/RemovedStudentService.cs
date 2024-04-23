using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Students;
using HaadCRM.Service.DTOs.StudentDTOs.RemovedStudents;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.RemovedStudents;

public class RemovedStudentService(IUnitOfWork unitOfWork, IMapper mapper) : IRemovedStudentService
{
    public async ValueTask<RemovedStudentViewModel> CreateAsync(RemovedStudentCreateModel createModel)
    {
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

    public async ValueTask<IEnumerable<RemovedStudentViewModel>> GetAllAsync()
    {
        var removedStudents = await unitOfWork.RemovedStudents.SelectAsEnumerableAsync(
            expression: rs => !rs.IsDeleted,
            includes: ["Student", "Group"]);
        return mapper.Map<IEnumerable<RemovedStudentViewModel>>(removedStudents);
    }


    public async ValueTask<RemovedStudentViewModel> UpdateAsync(long id, RemovedStudentUpdateModel updateModel)
    {
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