using HaadCRM.Service.Configurations;
using HaadCRM.Service.DTOs.Attendances;

namespace HaadCRM.Service.Services.Attendances;

public interface IAttendanceService
{
    ValueTask<AttendanceViewModel> CreateAsync(AttendanceCreateModel attendance);
    ValueTask<AttendanceViewModel> GetByIdAsync(long id);
    ValueTask<IEnumerable<AttendanceViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<AttendanceViewModel> UpdateAsync(long id, AttendanceUpdateModel attendance);
    ValueTask<bool> DeleteAsync(long id);
}