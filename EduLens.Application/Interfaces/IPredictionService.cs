
using EduLens.Application.DTOs;

namespace EduLens.Application.Interfaces;

public interface IPredictionService
{
    Task<PredictionDto?> GetByIdAsync(int id);

    Task<IEnumerable<PredictionDto>> GetAllAsync();

    Task<PredictionDto> CreateAsync(CreatePredictionDto predictionDto);

    Task<bool> UpdateAsync(int id, UpdatePredictionDto predictionDto);

    Task<bool> DeleteAsync(int id);
}
