
namespace EduLens.Application.DTOs;

public class AttendanceDto
{
    public int AttendanceId { get; set; }

    public int EnrollmentId { get; set; }

    public string StudentNumber { get; set; } = string.Empty;

    public string CourseCode { get; set; } = string.Empty;

    public DateTime Date { get; set; }

    public bool IsPresent { get; set; }
}

public class CreateAttendanceDto
{
    public int EnrollmentId { get; set; }

    public DateTime Date { get; set; }

    public bool IsPresent { get; set; }
}

public class UpdateAttendanceDto
{
    public int EnrollmentId { get; set; }

    public DateTime Date { get; set; }

    public bool IsPresent { get; set; }
}
