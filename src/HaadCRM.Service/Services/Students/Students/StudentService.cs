using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Students;
using HaadCRM.Service.DTOs.StudentDTOs.Students;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.Students.Students;

public class StudentService(IUnitOfWork unitOfWork, IMapper mapper) : IStudentService
{
    public async ValueTask<StudentViewModel> CreateAsync(StudentCreateModel createModel)
    {
        var exist = unitOfWork.Students.SelectAsync(u => u.UserId == createModel.UserId);
        if (exist != null)
            throw new AlreadyExistException("This student is already exists");

        await unitOfWork.Students.InsertAsync(mapper.Map<Student>(createModel));
        await unitOfWork.SaveAsync();
        return await Task.FromResult(mapper.Map<StudentViewModel>(createModel));
    }

    public async ValueTask<StudentViewModel> UpdateAsync(long id, StudentUpdateModel updateModel)
    {
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

    public async ValueTask<IEnumerable<StudentViewModel>> GetAllAsync()
    {
        var students = await unitOfWork.Students.SelectAsEnumerableAsync(
            expression: s => !s.IsDeleted,
            includes: ["User", "Asset"]);
        return mapper.Map<IEnumerable<StudentViewModel>>(students);
    }
}
