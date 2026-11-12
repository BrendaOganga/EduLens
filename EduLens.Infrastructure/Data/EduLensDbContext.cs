using EduLens.Domain.Entities;
using EduLens.Infrastructure.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace EduLens.Infrastructure.Data;

public class EduLensDbContext : DbContext
{
    public EduLensDbContext(DbContextOptions<EduLensDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Student> Students => Set<Student>();
    public DbSet<Lecturer> Lecturers => Set<Lecturer>();
    public DbSet<Department> Departments => Set<Department>();
    public DbSet<Programme> Programmes => Set<Programme>();
    public DbSet<Course> Courses => Set<Course>();
    public DbSet<Enrollment> Enrollments => Set<Enrollment>();
    public DbSet<Assessment> Assessments => Set<Assessment>();
    public DbSet<Attendance> Attendances => Set<Attendance>();
    public DbSet<Prediction> Predictions => Set<Prediction>();
    public DbSet<Notification> Notifications => Set<Notification>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        DatabaseConfigurations.Configure(modelBuilder);
    }
}