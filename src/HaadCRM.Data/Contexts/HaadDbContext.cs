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
using Microsoft.EntityFrameworkCore;

namespace HaadCRM.Data.Contexts;

public class HaadDbContext : DbContext
{
    public HaadDbContext(DbContextOptions<HaadDbContext> options ) : base(options) { }
    public DbSet<Asset> Assets { get; set; }
    public DbSet<Attendance> Attendances { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<EmployeeRole> EmployeeRoles { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<ExamFile> ExamFiles { get; set; }
    public DbSet<ExamGrade> ExamGrades { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<GroupStudent> GroupStudents { get; set; }
    public DbSet<Homework> Homeworks { get; set; }
    public DbSet<HomeworkFile> HomeworkFiles { get; set; }
    public DbSet<HomeworkGrade> HomeworkGrades { get; set; }
    public DbSet<Lesson> Lessons { get; set; }
    public DbSet<LessonFile> LessonFiles { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<RemovedStudent> RemovedStudents { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRole> UserRoles { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<UserPermission> UserPermissions { get; set; }
}
