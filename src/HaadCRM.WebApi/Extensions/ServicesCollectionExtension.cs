using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Data.Repositories;
using HaadCRM.WebApi.Middlewares;
using HaadCRM.Service.Services.Users;
using HaadCRM.Service.Services.Assets;
using HaadCRM.Service.Services.Lessons;
using HaadCRM.Service.Services.Courses;
using HaadCRM.Service.Services.Homework;
using HaadCRM.Service.Services.UserRoles;
using HaadCRM.Service.Services.Employees;
using HaadCRM.Service.Services.Attendances;
using HaadCRM.Service.Services.LessonFiles;
using HaadCRM.Service.Services.Exams.Exams;
using HaadCRM.Service.Services.Permissions;
using HaadCRM.Service.Services.AuthServices;
using HaadCRM.Service.Services.GroupService;
using HaadCRM.Service.Services.HomeworkFiles;
using HaadCRM.Service.Services.EmployeeRoles;
using HaadCRM.Service.Services.GroupStudents;
using HaadCRM.Service.Services.HomeworkGrades;
using HaadCRM.Service.Services.Exams.ExamFiles;
using HaadCRM.Service.Services.UserPermissions;
using HaadCRM.Service.Services.RemovedStudents;
using HaadCRM.Service.Services.Exams.ExamGrades;
using HaadCRM.Service.Services.Students.Students;

namespace HaadCRM.WebApi.Extensions;

public static class ServicesCollectionExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
        services.AddScoped<IAssetService, AssetService>();
        services.AddScoped<IAttendanceService, AttendanceService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICourceService, CourseService>();
        services.AddScoped<IEmployeeRoleService, EmployeeRoleService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IExamFileService, ExamFileService>();
        services.AddScoped<IExamGradeService, ExamGradeService>();
        services.AddScoped<IExamService, ExamService>();
        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<IGroupStudentService, GroupStudentService>();
        services.AddScoped<IHomeworkFilesService, HomeworkFilesService>();
        services.AddScoped<IHomeworkGradeService, HomeworkGradeService>();
        services.AddScoped<IHomeWorkService, HomeworkService>();
        services.AddScoped<ILessonFilesService, LessonFilesService>();
        services.AddScoped<ILessonService, LessonService>();
        services.AddScoped<IPermissionService, PermissionService>();
        services.AddScoped<IRemovedStudentService, RemovedStudentService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IUserPermissionService, UserPermissionService>();
        services.AddScoped<IUserRoleService, UserRoleService>();
        services.AddScoped<IUserService, UserService>();
    }

    public static void AddExceptionHandlers(this IServiceCollection services)
    {
        services.AddExceptionHandler<NotFoundExceptionHandler>();
        services.AddExceptionHandler<AlreadyExistExceptionHandler>();
        services.AddExceptionHandler<ArgumentIsNotValidExceptionHandler>();
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddExceptionHandler<InternalServerExceptionHandler>();
    }
}
