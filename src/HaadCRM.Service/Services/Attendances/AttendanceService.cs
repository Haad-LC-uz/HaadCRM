using AutoMapper;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Domain.Entities.Attendances;
using HaadCRM.Service.DTOs.Attendances;
using HaadCRM.Service.Exceptions;

namespace HaadCRM.Service.Services.Attendances;

public class AttendanceService(IUnitOfWork unitOfWork, IMapper mapper) : IAttendanceService
{
    public async ValueTask<AttendanceViewModel> CreateAsync(AttendanceCreateModel createModel)
    {
        var existAttendance = await unitOfWork.Attendances.SelectAsync(attendance =>
            attendance.LessonId == createModel.LessonId && attendance.StudentId == createModel.StudentId);

        if (existAttendance is not null)
            throw new AlreadyExistException($"Attendance to this student at this lesson already exists");

        var attendance = mapper.Map<Attendance>(createModel);

        await unitOfWork.Attendances.InsertAsync(attendance);
        await unitOfWork.SaveAsync();

        return mapper.Map<AttendanceViewModel>(attendance);
    }

    public async ValueTask<AttendanceViewModel> GetByIdAsync(long id)
    {
        var attendance = await unitOfWork.Attendances.SelectAsync(a => a.Id == id)
                         ?? throw new NotFoundException($"Attendance with ID={id} is not found");

        return mapper.Map<AttendanceViewModel>(attendance);
    }

    public async ValueTask<IEnumerable<AttendanceViewModel>> GetAllAsync()
    {
        var attendances = await unitOfWork.Attendances.SelectAsEnumerableAsync();

        return mapper.Map<IEnumerable<AttendanceViewModel>>(attendances);
    }

    public async ValueTask<AttendanceViewModel> UpdateAsync(long id, AttendanceUpdateModel updateModel)
    {
        var attendance = await unitOfWork.Attendances.SelectAsync(a => a.Id == id)
                         ?? throw new NotFoundException($"Attendance with ID={id} is not found");

        mapper.Map(updateModel, attendance);

        await unitOfWork.Attendances.UpdateAsync(attendance);
        await unitOfWork.SaveAsync();

        return mapper.Map<AttendanceViewModel>(attendance);
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var attendance = await unitOfWork.Attendances.SelectAsync(a => a.Id == id)
                         ?? throw new NotFoundException($"Attendance with ID={id} is not found");

        await unitOfWork.Attendances.DeleteAsync(attendance);
        await unitOfWork.SaveAsync();

        return true;
    }
}