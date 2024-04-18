using HaadCRM.Data.Contexts;
using HaadCRM.Data.Repositories;
using HaadCRM.Domain.Commons;
using HaadCRM.Domain.Entities.Attendances;
using HaadCRM.Domain.Entities.Courses;
using HaadCRM.Domain.Entities.Employees;
using HaadCRM.Domain.Entities.Exams;
using HaadCRM.Domain.Entities.Groups;
using HaadCRM.Domain.Entities.Homeworks;
using HaadCRM.Domain.Entities.Lessons;
using HaadCRM.Domain.Entities.Students;
using HaadCRM.Domain.Entities.Users;

namespace HaadCRM.Data.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private readonly HaadDbContext _context;

    public IRepository<Asset> Assets { get; }
    public IRepository<Attendance> Attendances { get; }
    public IRepository<Course> Courses { get; }
    public IRepository<Employee> Employees { get; }
    public IRepository<EmployeeRole> EmployeeRoles { get; }
    public IRepository<Exam> Exams { get; }
    public IRepository<ExamFile> ExamFiles { get; }
    public IRepository<ExamGrade> ExamGrades { get; }
    public IRepository<Group> Groups { get; }
    public IRepository<GroupStudent> GroupStudents { get; }
    public IRepository<Homework> Homeworks { get; }
    public IRepository<HomeworkFile> HomeworkFiles { get; }
    public IRepository<HomeworkGrade> HomeworkGrades { get; }
    public IRepository<Lesson> Lessons { get; }
    public IRepository<LessonFile> LessonFiles { get; }
    public IRepository<Student> Students { get; }
    public IRepository<RemovedStudent> RemovedStudents { get; }
    public IRepository<User> Users { get; }
    public IRepository<UserRole> UserRoles { get; }
    public IRepository<Permission> Permissions { get; }
    public IRepository<UserPermission> UserPermissions { get; }

    public UnitOfWork(HaadDbContext context)
    {
        _context = context;

        Assets = new Repository<Asset>(_context);
        Attendances = new Repository<Attendance>(_context);
        Courses = new Repository<Course>(_context);
        Employees = new Repository<Employee>(_context);
        EmployeeRoles = new Repository<EmployeeRole>(_context);
        Exams = new Repository<Exam>(_context);
        ExamFiles = new Repository<ExamFile>(_context);
        ExamGrades = new Repository<ExamGrade>(_context);
        Groups = new Repository<Group>(_context);
        GroupStudents = new Repository<GroupStudent>(_context);
        Homeworks = new Repository<Homework>(_context);
        HomeworkFiles = new Repository<HomeworkFile>(_context);
        HomeworkGrades = new Repository<HomeworkGrade>(_context);
        Lessons = new Repository<Lesson>(_context);
        LessonFiles = new Repository<LessonFile>(_context);
        Students = new Repository<Student>(_context);
        RemovedStudents = new Repository<RemovedStudent>(_context);
        Users = new Repository<User>(_context);
        UserRoles = new Repository<UserRole>(_context);
        Permissions = new Repository<Permission>(_context);
        UserPermissions = new Repository<UserPermission>(_context);
    }


    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }

    public async ValueTask<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}