namespace EduLens.Application.DTOs;

public class CourseDto
{
    public int CourseId { get; set; }

    public string CourseCode { get; set; } = string.Empty;

    public string CourseName { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = string.Empty;

    public int Credits { get; set; }
}

public class CreateCourseDto
{
    public string CourseCode { get; set; } = string.Empty;

    public string CourseName { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public int Credits { get; set; }
}

public class UpdateCourseDto
{
    public string CourseCode { get; set; } = string.Empty;

    public string CourseName { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public int Credits { get; set; }
}