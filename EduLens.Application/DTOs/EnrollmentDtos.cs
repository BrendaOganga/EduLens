
using EduLens.Domain.Enums;

namespace EduLens.Application.DTOs;

public class EnrollmentDto
{
    public int EnrollmentId { get; set; }

    public int StudentId { get; set; }

    public string StudentNumber { get; set; } = string.Empty;

    public int CourseId { get; set; }

    public string CourseCode { get; set; } = string.Empty;

    public string CourseName { get; set; } = string.Empty;

    public Semester Semester { get; set; }

    public int AcademicYear { get; set; }
}

public class CreateEnrollmentDto
{
    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public Semester Semester { get; set; }

    public int AcademicYear { get; set; }
}

public class UpdateEnrollmentDto
{
    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public Semester Semester { get; set; }

    public int AcademicYear { get; set; }
}
