namespace EduLens.Application.DTOs;

public class UpdateStudentDto
{
    public string StudentNumber { get; set; } = string.Empty;

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public int ProgrammeId { get; set; }

    public int YearOfStudy { get; set; }
}