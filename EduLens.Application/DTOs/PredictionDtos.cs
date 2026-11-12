
namespace EduLens.Application.DTOs;

public class PredictionDto
{
    public int PredictionId { get; set; }

    public int StudentId { get; set; }

    public string StudentNumber { get; set; } = string.Empty;

    public string RiskLevel { get; set; } = string.Empty;

    public decimal Probability { get; set; }

    public string ModelVersion { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}

public class CreatePredictionDto
{
    public int StudentId { get; set; }

    public string RiskLevel { get; set; } = string.Empty;

    public decimal Probability { get; set; }

    public string ModelVersion { get; set; } = string.Empty;
}

public class UpdatePredictionDto
{
    public string RiskLevel { get; set; } = string.Empty;

    public decimal Probability { get; set; }

    public string ModelVersion { get; set; } = string.Empty;
}
