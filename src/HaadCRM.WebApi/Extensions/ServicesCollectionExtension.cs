using HaadCRM.Data.Repositories;
using HaadCRM.Data.UnitOfWorks;
using HaadCRM.Service.Services.Assets;
using HaadCRM.Service.Services.Attendances;
using HaadCRM.Service.Services.AuthServices;
using HaadCRM.Service.Services.Courses;
using HaadCRM.Service.Services.EmployeeRoles;
using HaadCRM.Service.Services.Employees;
using HaadCRM.Service.Services.ExamFiles;
using HaadCRM.Service.Services.ExamGrades;
using HaadCRM.Service.Services.Exams.Exams;
using HaadCRM.Service.Services.GroupService;
using HaadCRM.Service.Services.GroupStudents;
using HaadCRM.Service.Services.HomeworkFiles;
using HaadCRM.Service.Services.HomeworkGrades;
using HaadCRM.Service.Services.HomeworkServices;
using HaadCRM.Service.Services.LessonFiles;
using HaadCRM.Service.Services.Lessons;
using HaadCRM.Service.Services.Options;
using HaadCRM.Service.Services.Permissions;
using HaadCRM.Service.Services.RemovedStudents;
using HaadCRM.Service.Services.Students.Students;
using HaadCRM.Service.Services.UserPermissions;
using HaadCRM.Service.Services.UserRoles;
using HaadCRM.Service.Services.Users;
using HaadCRM.Service.Validators.Attendances;
using HaadCRM.Service.Validators.Cources;
using HaadCRM.Service.Validators.Employees.EmployeeRoles;
using HaadCRM.Service.Validators.Employees.Employees;
using HaadCRM.Service.Validators.Exams.ExamFiles;
using HaadCRM.Service.Validators.Exams.ExamGrades;
using HaadCRM.Service.Validators.Exams.Exams;
using HaadCRM.Service.Validators.Groups.Groups;
using HaadCRM.Service.Validators.Groups.GroupStudents;
using HaadCRM.Service.Validators.Homework.Homework;
using HaadCRM.Service.Validators.Homework.HomeworkFiles;
using HaadCRM.Service.Validators.Homework.HomeworkGrades;
using HaadCRM.Service.Validators.Lessons.LessonFiles;
using HaadCRM.Service.Validators.Lessons.Lessons;
using HaadCRM.Service.Validators.Students.RemovedStudents;
using HaadCRM.Service.Validators.Students.Students;
using HaadCRM.Service.Validators.Users.Permissions;
using HaadCRM.Service.Validators.Users.UserPermissions;
using HaadCRM.Service.Validators.Users.UserRoles;
using HaadCRM.Service.Validators.Users.Users;
using HaadCRM.WebApi.MiddleWares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

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
        services.AddScoped<ICourseService, CourseService>();
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
    public static void AddValidators(this IServiceCollection services)
    {
        services.AddTransient<AttendanceCreateModelValidator>();
        services.AddTransient<AttendanceUpdateModelValidator>();
        services.AddTransient<CourseCreateModelValidator>();
        services.AddTransient<CourseUpdateModelValidator>();
        services.AddTransient<EmployeeRoleCreateModelValidator>();
        services.AddTransient<EmployeeRoleUpdateModelValidator>();
        services.AddTransient<EmployeeCreateModelValidator>();
        services.AddTransient<EmployeeUpdateModelValidator>();
        services.AddTransient<ExamFileCreateModelValidator>();
        services.AddTransient<ExamFileUpdateModelValidator>();
        services.AddTransient<ExamGradeCreateModelValidator>();
        services.AddTransient<ExamGradeUpdateModelValidator>();
        services.AddTransient<ExamCreateModelValidator>();
        services.AddTransient<ExamUpdateModelValidator>();
        services.AddTransient<GroupCreateModelValidator>();
        services.AddTransient<GroupUpdateModelValidator>();
        services.AddTransient<GroupStudentCreateModelValidator>();
        services.AddTransient<GroupStudentUpdateModelValidator>();
        services.AddTransient<HomeworkCreateModelValidator>();
        services.AddTransient<HomeworkUpdateModelValidator>();
        services.AddTransient<HomeworkFileCreateModelValidator>();
        services.AddTransient<HomeworkFileUpdateModelValidator>();
        services.AddTransient<HomeworkGradeCreateModelValidator>();
        services.AddTransient<HomeworkGradeUpdateModelValidator>();
        services.AddTransient<LessonFileCreateModelValidator>();
        services.AddTransient<LessonFileUpdateModelValidator>();
        services.AddTransient<LessonCreateModelValidator>();
        services.AddTransient<LessonUpdateModelValidator>();
        services.AddTransient<RemovedStudentCreateModelValidator>();
        services.AddTransient<RemovedStudentUpdateModelValidator>();
        services.AddTransient<StudentCreateModelValidator>();
        services.AddTransient<StudentUpdateModelValidator>();
        services.AddTransient<PermissionCreateModelValidator>();
        services.AddTransient<PermissionUpdateModelValidator>();
        services.AddTransient<UserPermissionCreateModelValidator>();
        services.AddTransient<UserPermissionUpdateModelValidator>();
        services.AddTransient<UserRoleCreateModelValidator>();
        services.AddTransient<UserRoleUpdateModelValidator>();
        services.AddTransient<UserCreateModelValidator>();
        services.AddTransient<UserUpdateModelValidator>();
    }

    public static void AddJwtService(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOption>(configuration.GetSection("JWT"));
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"])),
                ClockSkew = TimeSpan.Zero
            };
        });
    }

    public static void AddSwaggerGenJwt(this IServiceCollection services)
    {
        var jwtSecurityScheme = new OpenApiSecurityScheme
        {
            BearerFormat = "JWT",
            Name = "JWT Authentication",
            In = ParameterLocation.Header,
            Type = SecuritySchemeType.Http,
            Scheme = JwtBearerDefaults.AuthenticationScheme,
            Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

            Reference = new OpenApiReference()
            {
                Id = JwtBearerDefaults.AuthenticationScheme,
                Type = ReferenceType.SecurityScheme
            }
        };

        services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                { jwtSecurityScheme, Array.Empty<string>() }
            });
        });
    }
    
}
