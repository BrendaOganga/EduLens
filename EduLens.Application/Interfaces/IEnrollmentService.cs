
using EduLens.Application.DTOs;

namespace EduLens.Application.Interfaces;

public interface IEnrollmentService
{
    Task<EnrollmentDto?> GetByIdAsync(int id);

    Task<IEnumerable<EnrollmentDto>> GetAllAsync();

    Task<EnrollmentDto> CreateAsync(CreateEnrollmentDto enrollmentDto);

    Task<EnrollmentDto?> UpdateAsync(int id, UpdateEnrollmentDto enrollmentDto);

    Task<bool> DeleteAsync(int id);
}
