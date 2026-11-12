namespace EduLens.Domain.Entities;

public class Prediction
{
    public int PredictionId { get; set; }

    public int StudentId { get; set; }

    public string RiskLevel { get; set; } = string.Empty;

    public decimal Probability { get; set; }

    public string ModelVersion { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }

    public Student Student { get; set; } = null!;
}