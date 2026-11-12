namespace EduLens.Domain.Entities;

public class Course
{
    public int CourseId { get; set; }

    public string CourseCode { get; set; } = string.Empty;

    public string CourseName { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public int Credits { get; set; }

    public Department Department { get; set; } = null!;
}