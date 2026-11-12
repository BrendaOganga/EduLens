using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;

namespace EduLens.Application.Services;

public class ProgrammeService : IProgrammeService
{
    private readonly IProgrammeRepository _programmeRepository;

    public ProgrammeService(IProgrammeRepository programmeRepository)
    {
        _programmeRepository = programmeRepository;
    }

    public async Task<ProgrammeDto?> GetByIdAsync(int programmeId)
    {
        var programme = await _programmeRepository.GetByIdAsync(programmeId);

        if (programme == null)
            return null;

        return MapToDto(programme);
    }

    public async Task<IEnumerable<ProgrammeDto>> GetAllAsync()
    {
        var programmes = await _programmeRepository.GetAllAsync();

        return programmes.Select(MapToDto);
    }

    public async Task<ProgrammeDto> CreateAsync(CreateProgrammeDto programmeDto)
    {
        var programme = new Programme
        {
            ProgrammeName = programmeDto.ProgrammeName,
            DepartmentId = programmeDto.DepartmentId
        };

        var createdProgramme = await _programmeRepository.CreateAsync(programme);

        // Reload the programme with its Department navigation property
        var savedProgramme = await _programmeRepository.GetByIdAsync(
            createdProgramme.ProgrammeId);

        return MapToDto(savedProgramme!);
    }

    public async Task<ProgrammeDto?> UpdateAsync(
        int programmeId, UpdateProgrammeDto programmeDto)
    {
        var programme = await _programmeRepository.GetByIdAsync(programmeId);

        if (programme == null)
            return null;

        programme.ProgrammeName = programmeDto.ProgrammeName;
        programme.DepartmentId = programmeDto.DepartmentId;

        var updatedProgramme = await _programmeRepository.UpdateAsync(programme);

        if (updatedProgramme == null)
            return null;

        return MapToDto(updatedProgramme);
    }

    public async Task<bool> DeleteAsync(int programmeId)
    {
        return await _programmeRepository.DeleteAsync(programmeId);
    }

    private static ProgrammeDto MapToDto(Programme programme)
    {
        return new ProgrammeDto
        {
            ProgrammeId = programme.ProgrammeId,
            ProgrammeName = programme.ProgrammeName,
            DepartmentId = programme.DepartmentId,
            DepartmentName = programme.Department.DepartmentName
        };
    }
}