namespace EduLens.Domain.Entities;

public class Assessment
{
    public int AssessmentId { get; set; }

    public int EnrollmentId { get; set; }

    public string AssessmentType { get; set; } = string.Empty;

    public decimal Score { get; set; }

    public decimal MaximumScore { get; set; }

    public DateTime AssessmentDate { get; set; }

    // Navigation property
    public Enrollment Enrollment { get; set; } = null!;
}