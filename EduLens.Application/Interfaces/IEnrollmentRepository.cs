
using EduLens.Domain.Entities;

namespace EduLens.Application.Interfaces;

public interface IEnrollmentRepository
{
    Task<Enrollment?> GetByIdAsync(int id);

    Task<IEnumerable<Enrollment>> GetAllAsync();

    Task<Enrollment> CreateAsync(Enrollment enrollment);

    Task<Enrollment?> UpdateAsync(int id, Enrollment enrollment);

    Task<bool> DeleteAsync(int id);
}
