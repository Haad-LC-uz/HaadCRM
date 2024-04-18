using AutoMapper;
using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Attendances;
using HaadCRM.Domain.Entities.Courses;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Domain.Entities.Exams;
using HaadCRM.Domain.Entities.Groups;
using HaadCRM.Domain.Entities.GroupStudents;
using HaadCRM.Domain.Entities.Homeworks;
using HaadCRM.Domain.Entities.Lessons;
using HaadCRM.Domain.Entities.Students;
using HaadCRM.Domain.Entities.Users;
using HaadCRM.Service.DTOs.Assets;
using HaadCRM.Service.DTOs.Attendencies;
using HaadCRM.Service.DTOs.Courses;
using HaadCRM.Service.DTOs.EmployeeRoles;
using HaadCRM.Service.DTOs.Employees;
using HaadCRM.Service.DTOs.ExamFiles;
using HaadCRM.Service.DTOs.ExamGrades;
using HaadCRM.Service.DTOs.Exams;
using HaadCRM.Service.DTOs.Groups;
using HaadCRM.Service.DTOs.GroupStudents;
using HaadCRM.Service.DTOs.HomeworkFiles;
using HaadCRM.Service.DTOs.HomeworkGrades;
using HaadCRM.Service.DTOs.Homeworks;
using HaadCRM.Service.DTOs.LessonFiles;
using HaadCRM.Service.DTOs.Lessons;
using HaadCRM.Service.DTOs.RemovedStudents;
using HaadCRM.Service.DTOs.Students.StudentDTOs;
using HaadCRM.Service.DTOs.Users.Permissions.PermissionDTOs;
using HaadCRM.Service.DTOs.Users.Permissions.UserPermissions;
using HaadCRM.Service.DTOs.Users.Users.UserDTOs;
using HaadCRM.Service.DTOs.Users.Users.UserRoles;

namespace HaadCRM.Service.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Attendance, AttendanceCreateModel>().ReverseMap();
        CreateMap<Attendance, AttendanceUpdateModel>().ReverseMap();
        CreateMap<Attendance, AttendanceViewModel>().ReverseMap();

        CreateMap<Course, CourseCreateModel>().ReverseMap();
        CreateMap<Course, CourseUpdateModel>().ReverseMap();
        CreateMap<Course, CourseViewModel>().ReverseMap();

        CreateMap<Employee, EmployeeCreateModel>().ReverseMap();
        CreateMap<Employee, EmployeeUpdateModel>().ReverseMap();
        CreateMap<Employee, EmployeeViewModel>().ReverseMap();

        CreateMap<EmployeeRole, EmployeeRoleCreateModel>().ReverseMap();
        CreateMap<EmployeeRole, EmployeeRoleUpdateModel>().ReverseMap();
        CreateMap<EmployeeRole, EmployeeRoleViewModel>().ReverseMap();

        CreateMap<Exam, ExamCreateModel>().ReverseMap();
        CreateMap<Exam, ExamUpdateModel>().ReverseMap();
        CreateMap<Exam, ExamViewModel>().ReverseMap();

        CreateMap<ExamFile, ExamFileCreateModel>().ReverseMap();
        CreateMap<ExamFile, ExamFileUpdateModel>().ReverseMap();
        CreateMap<ExamFile, ExamFileViewModel>().ReverseMap();

        CreateMap<ExamGrade, ExamGradeCreateModel>().ReverseMap();
        CreateMap<ExamGrade, ExamGradeUpdateModel>().ReverseMap();
        CreateMap<ExamGrade, ExamGradeViewModel>().ReverseMap();

        CreateMap<Group, GroupCreateModel>().ReverseMap();
        CreateMap<Group, GroupUpdateModel>().ReverseMap();
        CreateMap<Group, GroupViewModel>().ReverseMap();

        CreateMap<GroupStudent, GroupStudentCreateModel>().ReverseMap();
        CreateMap<GroupStudent, GroupStudentUpdateModel>().ReverseMap();
        CreateMap<GroupStudent, GroupStudentViewModel>().ReverseMap();

        CreateMap<Homework, HomeworkCreateModel>().ReverseMap();
        CreateMap<Homework, HomeworkUpdateModel>().ReverseMap();
        CreateMap<Homework, HomeworkViewModel>().ReverseMap();

        CreateMap<HomeworkFile, HomeworkFileCreateModel>().ReverseMap();
        CreateMap<HomeworkFile, HomeworkFileUpdateModel>().ReverseMap();
        CreateMap<HomeworkFile, HomeworkFileViewModel>().ReverseMap();

        CreateMap<HomeworkGrade, HomeworkGradeCreateModel>().ReverseMap();
        CreateMap<HomeworkGrade, HomeworkGradeUpdateModel>().ReverseMap();
        CreateMap<HomeworkGrade, HomeworkGradeViewModel>().ReverseMap();

        CreateMap<Lesson, LessonCreateModel>().ReverseMap();
        CreateMap<Lesson, LessonUpdateModel>().ReverseMap();
        CreateMap<Lesson, LessonViewModel>().ReverseMap();

        CreateMap<LessonFile, LessonFileCreateModel>().ReverseMap();
        CreateMap<LessonFile, LessonFileUpdateModel>().ReverseMap();
        CreateMap<LessonFile, LessonViewModel>().ReverseMap();

        CreateMap<RemovedStudent, RemovedStudentCreateModel>().ReverseMap();
        CreateMap<RemovedStudent, RemovedStudentUpdateModel>().ReverseMap();
        CreateMap<RemovedStudent, RemovedStudentViewModel>().ReverseMap();

        CreateMap<Student, StudentCreateModel>().ReverseMap();
        CreateMap<Student, StudentUpdateModel>().ReverseMap();
        CreateMap<Student, StudentViewModel>().ReverseMap();

        CreateMap<User, UserCreateModel>().ReverseMap();
        CreateMap<User, UserUpdateModel>().ReverseMap();
        CreateMap<User, UserViewModel>().ReverseMap();

        CreateMap<UserRole, UserRoleCreateModel>().ReverseMap();
        CreateMap<UserRole, UserRoleUpdateModel>().ReverseMap();
        CreateMap<UserRole, UserRoleViewModel>().ReverseMap();

        CreateMap<Asset, AssetCreateModel>().ReverseMap();
        CreateMap<Asset, AssetUpdateModel>().ReverseMap();
        CreateMap<Asset, AssetViewModel>().ReverseMap();

        CreateMap<Permission, PermissionCreateModel>().ReverseMap();
        CreateMap<Permission, PermissionUpdateModel>().ReverseMap();
        CreateMap<Permission, PermissionViewModel>().ReverseMap();

        CreateMap<UserPermission, UserPermissionCreateModel>().ReverseMap();
        CreateMap<UserPermission, UserPermissionUpdateModel>().ReverseMap();
        CreateMap<UserPermission, UserPermissionViewModel>().ReverseMap();
    }
}
