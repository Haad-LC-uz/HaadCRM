using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Students;
using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.StudentDTOs.Students;
using HaadCRM.Service.Exceptions;
using HaadCRM.Service.Extensions;
using HaadCRM.Service.Validators.Lessons.Lessons;
using HaadCRM.Service.Validators.Students.Students;

namespace HaadCRM.Service.Services.Students.Students;

public class StudentService(
    IUnitOfWork unitOfWork, 
    IMapper mapper,
    StudentCreateModelValidator createModelValidator,
    StudentUpdateModelValidator updateModelValidator) : IStudentService
{
    public async ValueTask<StudentViewModel> CreateAsync(StudentCreateModel createModel)
    {
        await createModelValidator.ValidateOrPanicAsync(createModel);

        var exist = await unitOfWork.Students.SelectAsync(u => u.UserId == createModel.UserId);
        if (exist != null)
            throw new AlreadyExistException("This student is already exists");

        await unitOfWork.Students.InsertAsync(mapper.Map<Student>(createModel));
        await unitOfWork.SaveAsync();
        return await Task.FromResult(mapper.Map<StudentViewModel>(createModel));
    }

    public async ValueTask<StudentViewModel> UpdateAsync(long id, StudentUpdateModel updateModel)
    {
        await updateModelValidator.ValidateOrPanicAsync(updateModel);
        var student = await unitOfWork.Students.SelectAsync(user => user.Id == id)
            ?? throw new NotFoundException($"Student with ID={id} is not found");
        mapper.Map(updateModel, student);

        await unitOfWork.Students.UpdateAsync(student);
        await unitOfWork.SaveAsync();

        return await Task.FromResult(mapper.Map<StudentViewModel>(student));
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var exist = await unitOfWork.Students.SelectAsync(s => s.Id == id)
            ?? throw new NotFoundException($"This student with ID={id} is not found");

        await unitOfWork.Students.DeleteAsync(exist);
        await unitOfWork.SaveAsync();
        return true;
    }

    public async ValueTask<StudentViewModel> GetByIdAsync(long id)
    {
        var student = await unitOfWork.Students.SelectAsync(s => s.Id == id)
            ?? throw new NotFoundException($"This student with ID={id} is not found");

        return await Task.FromResult(mapper.Map<StudentViewModel>(student));
    }

    public async ValueTask<IEnumerable<StudentViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var students = unitOfWork.Students.SelectAsQueryable(
            expression: s => !s.IsDeleted,
            includes: ["User", "Asset"],
            isTracked: false).OrderBy(filter);

        return mapper.Map<IEnumerable<StudentViewModel>>(students);
    }
}
