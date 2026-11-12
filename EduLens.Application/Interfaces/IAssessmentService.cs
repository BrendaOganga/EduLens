using EduLens.Application.DTOs;

namespace EduLens.Application.Interfaces;

public interface IAssessmentService
{
    Task<AssessmentDto?> GetByIdAsync(int id);

    Task<IEnumerable<AssessmentDto>> GetAllAsync();

    Task<AssessmentDto> CreateAsync(CreateAssessmentDto assessmentDto);

    Task<AssessmentDto?> UpdateAsync(int id, UpdateAssessmentDto assessmentDto);

    Task<bool> DeleteAsync(int id);
}