namespace EduLens.Domain.Entities;

public class Student
{
    public int StudentId { get; set; }

    public int UserId { get; set; }

    public string StudentNumber { get; set; } = string.Empty;

    public int ProgrammeId { get; set; }

    public int YearOfStudy { get; set; }

    // Navigation property
    public User User { get; set; } = null!;

    public Programme Programme { get; set; } = null!;
}