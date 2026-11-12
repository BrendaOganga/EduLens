namespace EduLens.Domain.Entities;

public class Attendance
{
    public int AttendanceId { get; set; }

    public int EnrollmentId { get; set; }

    public DateTime Date { get; set; }

    public bool IsPresent { get; set; }

    // Navigation property
    public Enrollment Enrollment { get; set; } = null!;
}