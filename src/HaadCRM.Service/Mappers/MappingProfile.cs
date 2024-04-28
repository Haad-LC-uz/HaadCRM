using AutoMapper;
using HaadCRM.Domain.Commons;
using HaadCRM.Service.DTOs.Assets;
using HaadCRM.Service.DTOs.Courses;
using HaadCRM.Domain.Entities.Users;
using HaadCRM.Domain.Entities.Exams;
using HaadCRM.Domain.Entities.Groups;
using HaadCRM.Domain.Entities.Courses;
using HaadCRM.Domain.Entities.Lessons;
using HaadCRM.Domain.Entities.Students;
using HaadCRM.Service.DTOs.Attendances;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Domain.Entities.Homeworks;
using HaadCRM.Domain.Entities.Attendances;
using HaadCRM.Service.DTOs.ExamDTOs.Exams;
using HaadCRM.Service.DTOs.UserDTOs.Users;
using HaadCRM.Service.DTOs.GroupDTOs.Groups;
using HaadCRM.Service.DTOs.ExamDTOs.ExamFiles;
using HaadCRM.Service.DTOs.UserDTOs.UserRoles;
using HaadCRM.Service.DTOs.ExamDTOs.ExamGrades;
using HaadCRM.Service.DTOs.LessonsDTOs.Lessons;
using HaadCRM.Service.DTOs.StudentDTOs.Students;
using HaadCRM.Service.DTOs.UserDTOs.Permissions;
using HaadCRM.Service.DTOs.HomeworkDTOs.Homework;
using HaadCRM.Service.DTOs.EmployeeDTOs.Employees;
using HaadCRM.Service.DTOs.GroupDTOs.GroupStudents;
using HaadCRM.Service.DTOs.LessonsDTOs.LessonFiles;
using HaadCRM.Service.DTOs.UserDTOs.UserPermissions;
using HaadCRM.Service.DTOs.HomeworkDTOs.HomeworkFiles;
using HaadCRM.Service.DTOs.EmployeeDTOs.EmployeeRoles;
using HaadCRM.Service.DTOs.HomeworkDTOs.HomeworkGrades;
using HaadCRM.Service.DTOs.StudentDTOs.RemovedStudents;

namespace HaadCRM.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Attendance, AttendanceCreateModel>().ReverseMap();
        CreateMap<Attendance, AttendanceUpdateModel>().ReverseMap();
        CreateMap<Attendance, AttendanceViewModel>()
            .ForMember(dest => dest.IsAttended, opt => opt.MapFrom(src => src.IsAttended))
            .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Student))
            .ForMember(dest => dest.Lesson, opt => opt.MapFrom(src => src.Lesson));

        CreateMap<Course, CourseCreateModel>().ReverseMap();
        CreateMap<Course, CourseUpdateModel>().ReverseMap();
        CreateMap<Course, CourseViewModel>().ReverseMap();

        CreateMap<Employee, EmployeeCreateModel>().ReverseMap();
        CreateMap<Employee, EmployeeUpdateModel>().ReverseMap();
        CreateMap<Employee, EmployeeViewModel>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.EmployeeRole, opt => opt.MapFrom(src => src.EmployeeRole))
            .ForMember(dest => dest.Asset, opt => opt.MapFrom(src => src.Asset))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.Salary, opt => opt.MapFrom(src => src.Salary));

        CreateMap<EmployeeRole, EmployeeRoleCreateModel>().ReverseMap();
        CreateMap<EmployeeRole, EmployeeRoleUpdateModel>().ReverseMap();
        CreateMap<EmployeeRole, EmployeeRoleViewModel>().ReverseMap();

        CreateMap<Exam, ExamCreateModel>().ReverseMap();
        CreateMap<Exam, ExamUpdateModel>().ReverseMap();
        CreateMap<Exam, ExamViewModel>()
            .ForMember(dest => dest.Teacher, opt => opt.MapFrom(src => src.Teacher))
            .ForMember(dest => dest.Assistant, opt => opt.MapFrom(src => src.Assistant))
            .ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.Group))
            .ForMember(dest => dest.ProfilePicture, opt => opt.MapFrom(src => src.ProfilePicture))
            .ForMember(dest => dest.DateOfExam, opt => opt.MapFrom(src => src.DateOfExam))
            .ForMember(dest => dest.DeadLine, opt => opt.MapFrom(src => src.DeadLine));

        CreateMap<ExamFile, ExamFileCreateModel>().ReverseMap();
        CreateMap<ExamFile, ExamFileUpdateModel>().ReverseMap();
        CreateMap<ExamFile, ExamFileViewModel>()
            .ForMember(dest => dest.Asset, opt => opt.MapFrom(src => src.Asset))
            .ForMember(dest => dest.Exam, opt => opt.MapFrom(src => src.Exam));

        CreateMap<ExamGrade, ExamGradeCreateModel>().ReverseMap();
        CreateMap<ExamGrade, ExamGradeUpdateModel>().ReverseMap();
        CreateMap<ExamGrade, ExamGradeViewModel>()
                .ForMember(dest => dest.Exam, opt => opt.MapFrom(src => src.Exam))
                .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Student))
                .ForMember(dest => dest.Teacher, opt => opt.MapFrom(src => src.Teacher))
                .ForMember(dest => dest.Assistant, opt => opt.MapFrom(src => src.Assistant))
                .ReverseMap();

        CreateMap<Group, GroupCreateModel>().ReverseMap();
        CreateMap<Group, GroupUpdateModel>().ReverseMap();
        CreateMap<Group, GroupViewModel>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Course, opt => opt.MapFrom(src => src.Course))
            .ForMember(dest => dest.Teacher, opt => opt.MapFrom(src => src.Teacher))
            .ForMember(dest => dest.Assistant, opt => opt.MapFrom(src => src.Assistant))
            .ForMember(dest => dest.StartTime, opt => opt.MapFrom(src => src.StartTime))
            .ForMember(dest => dest.Duration, opt => opt.MapFrom(src => src.Duration))
            .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.EndTime))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Room, opt => opt.MapFrom(src => src.Room));

        CreateMap<GroupStudent, GroupStudentCreateModel>().ReverseMap();
        CreateMap<GroupStudent, GroupStudentUpdateModel>().ReverseMap();
        CreateMap<GroupStudent, GroupStudentViewModel>()
            .ForMember(dest => dest.IsPaid, opt => opt.MapFrom(src => src.IsPaid))
            .ForMember(dest => dest.IsPassed, opt => opt.MapFrom(src => src.IsPassed))
            .ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.Group))
            .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Student));

        CreateMap<Homework, HomeworkCreateModel>().ReverseMap();
        CreateMap<Homework, HomeworkUpdateModel>().ReverseMap();
        CreateMap<Homework, HomeworkViewModel>()
            .ForMember(dest => dest.Lesson, opt => opt.MapFrom(src => src.Lesson))
            .ForMember(dest => dest.Assistant, opt => opt.MapFrom(src => src.Assistant))
            .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
            .ForMember(dest => dest.DeadLine, opt => opt.MapFrom(src => src.DeadLine));

        CreateMap<HomeworkFile, HomeworkFileCreateModel>().ReverseMap();
        CreateMap<HomeworkFile, HomeworkFileUpdateModel>().ReverseMap();
        CreateMap<HomeworkFile, HomeworkFileViewModel>()
            .ForMember(dest => dest.Homework, opt => opt.MapFrom(src => src.Homework))
            .ForMember(dest => dest.Asset, opt => opt.MapFrom(src => src.Asset));

        CreateMap<HomeworkGrade, HomeworkGradeCreateModel>().ReverseMap();
        CreateMap<HomeworkGrade, HomeworkGradeUpdateModel>().ReverseMap();
        CreateMap<HomeworkGrade, HomeworkGradeViewModel>()
            .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Student))
            .ForMember(dest => dest.Assistant, opt => opt.MapFrom(src => src.Assistant))
            .ForMember(dest => dest.Homework, opt => opt.MapFrom(src => src.Homework))
            .ForMember(dest => dest.Grade, opt => opt.MapFrom(src => src.Grade));

        CreateMap<Lesson, LessonCreateModel>().ReverseMap();
        CreateMap<Lesson, LessonUpdateModel>().ReverseMap();
        CreateMap<Lesson, LessonViewModel>()
            .ForMember(dest => dest.DateOfLesson, opt => opt.MapFrom(src => src.DateOfLesson))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.Group));

        CreateMap<LessonFile, LessonFileCreateModel>().ReverseMap();
        CreateMap<LessonFile, LessonFileUpdateModel>().ReverseMap();
        CreateMap<LessonFile, LessonFileViewModel>()
            .ForMember(dest => dest.Lesson, opt => opt.MapFrom(src => src.Lesson))
            .ForMember(dest => dest.Asset, opt => opt.MapFrom(src => src.Asset));

        CreateMap<RemovedStudent, RemovedStudentCreateModel>().ReverseMap();
        CreateMap<RemovedStudent, RemovedStudentUpdateModel>().ReverseMap();
        CreateMap<RemovedStudent, RemovedStudentViewModel>()
            .ForMember(dest => dest.Reason, opt => opt.MapFrom(src => src.Reason))
            .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Student))
            .ForMember(dest => dest.Group, opt => opt.MapFrom(src => src.Group));

        CreateMap<Student, StudentCreateModel>().ReverseMap();
        CreateMap<Student, StudentUpdateModel>().ReverseMap();
        CreateMap<Student, StudentViewModel>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.Asset, opt => opt.MapFrom(src => src.Asset));

        CreateMap<User, UserCreateModel>().ReverseMap();
        CreateMap<User, UserUpdateModel>().ReverseMap();
        CreateMap<User, UserViewModel>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone))
            .ForMember(dest => dest.UserRole, opt => opt.MapFrom(src => src.UserRole));

        CreateMap<UserRole, UserRoleCreateModel>().ReverseMap();
        CreateMap<UserRole, UserRoleUpdateModel>().ReverseMap();
        CreateMap<UserRole, UserRoleViewModel>().ReverseMap();

        CreateMap<Asset, AssetCreateModel>().ReverseMap();
        CreateMap<Asset, AssetViewModel>().ReverseMap();

        CreateMap<Permission, PermissionCreateModel>().ReverseMap();
        CreateMap<Permission, PermissionUpdateModel>().ReverseMap();
        CreateMap<Permission, PermissionViewModel>().ReverseMap();

        CreateMap<UserPermission, UserPermissionCreateModel>().ReverseMap();
        CreateMap<UserPermission, UserPermissionUpdateModel>().ReverseMap();
        CreateMap<UserPermission, UserPermissionViewModel>()
            .ForMember(dest => dest.User, opt => opt.MapFrom(src => src.User))
            .ForMember(dest => dest.Permission, opt => opt.MapFrom(src => src.Permission));
    }
}
