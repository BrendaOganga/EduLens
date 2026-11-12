using EduLens.Domain.Enums;

namespace EduLens.Domain.Entities;

public class Enrollment
{
    public int EnrollmentId { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public Semester Semester { get; set; }

    public int AcademicYear { get; set; }

    // Navigation properties
    public Student Student { get; set; } = null!;

    public Course Course { get; set; } = null!;
}