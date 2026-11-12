using EduLens.Application.DTOs;

namespace EduLens.Application.Interfaces;

public interface IProgrammeService
{
    Task<ProgrammeDto?> GetByIdAsync(int programmeId);

    Task<IEnumerable<ProgrammeDto>> GetAllAsync();

    Task<ProgrammeDto> CreateAsync(CreateProgrammeDto programmeDto);

    Task<ProgrammeDto?> UpdateAsync(int programmeId, UpdateProgrammeDto programmeDto);

    Task<bool> DeleteAsync(int programmeId);
}