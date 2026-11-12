
using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;

namespace EduLens.Application.Services;

public class PredictionService : IPredictionService
{
    private readonly IPredictionRepository _predictionRepository;

    public PredictionService(IPredictionRepository predictionRepository)
    {
        _predictionRepository = predictionRepository;
    }

    public async Task<PredictionDto?> GetByIdAsync(int id)
    {
        var prediction = await _predictionRepository.GetByIdAsync(id);

        if (prediction == null)
            return null;

        return MapToDto(prediction);
    }

    public async Task<IEnumerable<PredictionDto>> GetAllAsync()
    {
        var predictions = await _predictionRepository.GetAllAsync();

        return predictions.Select(MapToDto);
    }

    public async Task<PredictionDto> CreateAsync(CreatePredictionDto predictionDto)
    {
        var prediction = new Prediction
        {
            StudentId = predictionDto.StudentId,
            RiskLevel = predictionDto.RiskLevel,
            Probability = predictionDto.Probability,
            ModelVersion = predictionDto.ModelVersion,
            CreatedAt = DateTime.UtcNow
        };

        var createdPrediction = await _predictionRepository.CreateAsync(prediction);

        return MapToDto(createdPrediction);
    }

    public async Task<bool> UpdateAsync(int id, UpdatePredictionDto predictionDto)
    {
        var prediction = await _predictionRepository.GetByIdAsync(id);

        if (prediction == null)
            return false;

        prediction.RiskLevel = predictionDto.RiskLevel;
        prediction.Probability = predictionDto.Probability;
        prediction.ModelVersion = predictionDto.ModelVersion;

        await _predictionRepository.UpdateAsync(prediction);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var prediction = await _predictionRepository.GetByIdAsync(id);

        if (prediction == null)
            return false;

        await _predictionRepository.DeleteAsync(prediction);

        return true;
    }

    private static PredictionDto MapToDto(Prediction prediction)
    {
        return new PredictionDto
        {
            PredictionId = prediction.PredictionId,
            StudentId = prediction.StudentId,
            StudentNumber = prediction.Student?.StudentNumber ?? string.Empty,
            RiskLevel = prediction.RiskLevel,
            Probability = prediction.Probability,
            ModelVersion = prediction.ModelVersion,
            CreatedAt = prediction.CreatedAt
        };
    }
}
