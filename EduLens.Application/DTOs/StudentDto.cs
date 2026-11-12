namespace EduLens.Application.DTOs;

public class StudentDto
{
    public int StudentId { get; set; }

    public string StudentNumber { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string ProgrammeName { get; set; } = string.Empty;

    public int YearOfStudy { get; set; }
}