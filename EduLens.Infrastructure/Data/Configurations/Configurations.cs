using EduLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduLens.Infrastructure.Data.Configurations;

public static class DatabaseConfigurations
{
    public static void Configure(ModelBuilder modelBuilder)
    {
        // USER
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(u => u.UserId);

            entity.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(500);

            entity.Property(u => u.Role)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            entity.Property(u => u.CreatedAt).IsRequired();

            entity.HasIndex(u => u.Email).IsUnique();
        });

        // STUDENT
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(s => s.StudentId);

            entity.Property(s => s.StudentNumber)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(s => s.YearOfStudy).IsRequired();

            entity.HasIndex(s => s.StudentNumber).IsUnique();
            entity.HasIndex(s => s.UserId).IsUnique();

            entity.HasOne(s => s.User)
                .WithOne()
                .HasForeignKey<Student>(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(s => s.Programme)
                .WithMany(p => p.Students)
                .HasForeignKey(s => s.ProgrammeId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // LECTURER
        modelBuilder.Entity<Lecturer>(entity =>
        {
            entity.HasKey(l => l.LecturerId);

            entity.Property(l => l.EmployeeNumber)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasIndex(l => l.EmployeeNumber).IsUnique();
            entity.HasIndex(l => l.UserId).IsUnique();

            entity.HasOne(l => l.User)
                .WithOne()
                .HasForeignKey<Lecturer>(l => l.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(l => l.Department)
                .WithMany(d => d.Lecturers)
                .HasForeignKey(l => l.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // DEPARTMENT
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(d => d.DepartmentId);

            entity.Property(d => d.DepartmentName)
                .IsRequired()
                .HasMaxLength(150);

            entity.HasIndex(d => d.DepartmentName).IsUnique();
        });

        // PROGRAMME
        modelBuilder.Entity<Programme>(entity =>
        {
            entity.HasKey(p => p.ProgrammeId);

            entity.Property(p => p.ProgrammeName)
                .IsRequired()
                .HasMaxLength(200);

            entity.HasOne(p => p.Department)
                .WithMany(d => d.Programmes)
                .HasForeignKey(p => p.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(p => new { p.DepartmentId, p.ProgrammeName })
                .IsUnique();
        });

        // COURSE
        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(c => c.CourseId);

            entity.Property(c => c.CourseCode)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(c => c.CourseName)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(c => c.Credits).IsRequired();

            entity.HasIndex(c => c.CourseCode).IsUnique();

            entity.HasOne(c => c.Department)
                .WithMany(d => d.Courses)
                .HasForeignKey(c => c.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);
        });

        // ENROLLMENT
        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.HasKey(e => e.EnrollmentId);

            entity.Property(e => e.Semester)
                .IsRequired()
                .HasConversion<string>()
                .HasMaxLength(20);

            entity.Property(e => e.AcademicYear).IsRequired();

            entity.HasOne(e => e.Student)
                .WithMany()
                .HasForeignKey(e => e.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasOne(e => e.Course)
                .WithMany()
                .HasForeignKey(e => e.CourseId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(e => new
            {
                e.StudentId,
                e.CourseId,
                e.Semester,
                e.AcademicYear
            }).IsUnique();
        });

        // ASSESSMENT
        modelBuilder.Entity<Assessment>(entity =>
        {
            entity.HasKey(a => a.AssessmentId);

            entity.Property(a => a.AssessmentType)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(a => a.Score)
                .IsRequired()
                .HasPrecision(5, 2);

            entity.Property(a => a.MaximumScore)
                .IsRequired()
                .HasPrecision(5, 2);

            entity.Property(a => a.AssessmentDate).IsRequired();

            entity.HasOne(a => a.Enrollment)
                .WithMany()
                .HasForeignKey(a => a.EnrollmentId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(a => a.EnrollmentId);

            entity.ToTable(t => t.HasCheckConstraint(
                "CK_Assessment_Score_Range",
                "[Score] >= 0 AND [Score] <= [MaximumScore]"
            ));
        });

        // ATTENDANCE
        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(a => a.AttendanceId);

            entity.Property(a => a.Date).IsRequired();
            entity.Property(a => a.IsPresent).IsRequired();

            entity.HasOne(a => a.Enrollment)
                .WithMany()
                .HasForeignKey(a => a.EnrollmentId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(a => new { a.EnrollmentId, a.Date })
                .IsUnique();
        });

        // PREDICTION
        modelBuilder.Entity<Prediction>(entity =>
        {
            entity.HasKey(p => p.PredictionId);

            entity.Property(p => p.RiskLevel)
                .IsRequired()
                .HasMaxLength(20);

            entity.Property(p => p.Probability)
                .IsRequired()
                .HasPrecision(5, 4);

            entity.Property(p => p.ModelVersion)
                .IsRequired()
                .HasMaxLength(50);

            entity.Property(p => p.CreatedAt).IsRequired();

            entity.HasOne(p => p.Student)
                .WithMany()
                .HasForeignKey(p => p.StudentId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasIndex(p => p.StudentId);
        });

        // NOTIFICATION
        modelBuilder.Entity<Notification>(entity =>
        {
            entity.HasKey(n => n.NotificationId);

            entity.Property(n => n.Title)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(n => n.Message)
                .IsRequired()
                .HasMaxLength(2000);

            entity.Property(n => n.IsRead).IsRequired();
            entity.Property(n => n.CreatedAt).IsRequired();

            entity.HasOne(n => n.User)
                .WithMany()
                .HasForeignKey(n => n.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        // AUDIT LOG
        modelBuilder.Entity<AuditLog>(entity =>
        {
            entity.HasKey(a => a.AuditLogId);

            entity.Property(a => a.Action)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(a => a.EntityName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(a => a.EntityId).IsRequired(false);

            entity.Property(a => a.Timestamp).IsRequired();

            entity.Property(a => a.IpAddress)
                .IsRequired(false)
                .HasMaxLength(45);

            entity.HasOne(a => a.User)
                .WithMany()
                .HasForeignKey(a => a.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(a => a.UserId);
            entity.HasIndex(a => a.Timestamp);
        });
    }
}