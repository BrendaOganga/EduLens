
using EduLens.Domain.Entities;

namespace EduLens.Application.Interfaces;

public interface IAssessmentRepository
{
    Task<Assessment?> GetByIdAsync(int id);

    Task<IEnumerable<Assessment>> GetAllAsync();

    Task<Assessment> CreateAsync(Assessment assessment);

    Task<Assessment?> UpdateAsync(int id, Assessment assessment);

    Task<bool> DeleteAsync(int id);
}
