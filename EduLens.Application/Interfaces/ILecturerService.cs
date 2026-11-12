using EduLens.Application.DTOs;

namespace EduLens.Application.Interfaces;

public interface ILecturerService
{
    Task<LecturerDto?> GetByIdAsync(int id);

    Task<IEnumerable<LecturerDto>> GetAllAsync();

    Task<LecturerDto> CreateAsync(CreateLecturerDto lecturerDto);

    Task<bool> UpdateAsync(int id, UpdateLecturerDto lecturerDto);

    Task<bool> DeleteAsync(int id);
}