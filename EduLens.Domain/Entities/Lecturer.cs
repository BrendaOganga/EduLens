namespace EduLens.Domain.Entities;

public class Lecturer
{
    public int LecturerId { get; set; }

    public int UserId { get; set; }

    public string EmployeeNumber { get; set; } = string.Empty;

    public int DepartmentId { get; set; }

    // Navigation properties
    public User User { get; set; } = null!;

    public Department Department { get; set; } = null!;
}