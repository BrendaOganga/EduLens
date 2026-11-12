namespace EduLens.Application.DTOs;

public class LecturerDto
{
    public int LecturerId { get; set; }

    public int UserId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string EmployeeNumber { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    public string DepartmentName { get; set; } = string.Empty;
}

public class CreateLecturerDto
{
    public int UserId { get; set; }

    public string EmployeeNumber { get; set; } = string.Empty;

    public int DepartmentId { get; set; }
}

public class UpdateLecturerDto
{
    public string EmployeeNumber { get; set; } = string.Empty;

    public int DepartmentId { get; set; }
}