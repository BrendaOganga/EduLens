
using EduLens.Domain.Entities;

namespace EduLens.Application.Interfaces;

public interface IPredictionRepository
{
    Task<Prediction?> GetByIdAsync(int id);

    Task<IEnumerable<Prediction>> GetAllAsync();

    Task<Prediction> CreateAsync(Prediction prediction);

    Task UpdateAsync(Prediction prediction);

    Task DeleteAsync(Prediction prediction);
}
