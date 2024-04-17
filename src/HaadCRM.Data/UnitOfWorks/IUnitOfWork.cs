using HaadCRM.Data.Repositories;
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

namespace HaadCRM.Data.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    IRepository<Asset> Assets { get; }
    IRepository<Attendance> Attendances { get; }
    IRepository<Course> Courses { get; }
    IRepository<Employee> Employees { get; }
    IRepository<EmployeeRole> EmployeeRoles { get; }
    IRepository<Exam> Exams { get; }
    IRepository<ExamFile> ExamFiles { get; }
    IRepository<ExamGrade> ExamGrades { get; }
    IRepository<Group> Groups { get; }
    IRepository<GroupStudent> GroupStudents { get; }
    IRepository<Homework> Homeworks { get; }
    IRepository<HomeworkFile> HomeworkFiles { get; }
    IRepository<HomeworkGrade> HomeworkGrades { get; }
    IRepository<Lesson> Lessons { get; }
    IRepository<LessonFile> LessonFiles { get; }
    IRepository<Student> Students { get; }
    IRepository<RemovedStudent> RemovedStudents { get; }
    IRepository<User> Users { get; }
    IRepository<UserRole> UserRoles { get; }
    IRepository<Permission> Permissions { get; }
    IRepository<UserPermission> UserPermissions { get; }
    ValueTask<bool> SaveAsync();
}
