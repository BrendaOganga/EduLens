using EduLens.Domain.Entities;

namespace EduLens.Application.Interfaces;

public interface IProgrammeRepository
{
    Task<Programme?> GetByIdAsync(int programmeId);

    Task<IEnumerable<Programme>> GetAllAsync();

    Task<Programme> CreateAsync(Programme programme);

    Task<Programme?> UpdateAsync(Programme programme);

    Task<bool> DeleteAsync(int programmeId);
}