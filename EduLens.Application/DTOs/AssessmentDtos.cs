
namespace EduLens.Application.DTOs;

public class AssessmentDto
{
    public int AssessmentId { get; set; }

    public int EnrollmentId { get; set; }

    public string StudentNumber { get; set; } = string.Empty;

    public string CourseCode { get; set; } = string.Empty;

    public string AssessmentType { get; set; } = string.Empty;

    public decimal Score { get; set; }

    public decimal MaximumScore { get; set; }

    public DateTime AssessmentDate { get; set; }
}

public class CreateAssessmentDto
{
    public int EnrollmentId { get; set; }

    public string AssessmentType { get; set; } = string.Empty;

    public decimal Score { get; set; }

    public decimal MaximumScore { get; set; }

    public DateTime AssessmentDate { get; set; }
}

public class UpdateAssessmentDto
{
    public int EnrollmentId { get; set; }

    public string AssessmentType { get; set; } = string.Empty;

    public decimal Score { get; set; }

    public decimal MaximumScore { get; set; }

    public DateTime AssessmentDate { get; set; }
}
