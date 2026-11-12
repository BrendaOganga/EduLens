using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;

namespace EduLens.Application.Services;

public class LecturerService : ILecturerService
{
    private readonly ILecturerRepository _lecturerRepository;

    public LecturerService(ILecturerRepository lecturerRepository)
    {
        _lecturerRepository = lecturerRepository;
    }

    // GET BY ID
    public async Task<LecturerDto?> GetByIdAsync(int id)
    {
        var lecturer = await _lecturerRepository.GetByIdAsync(id);

        if (lecturer == null)
            return null;

        return MapToDto(lecturer);
    }

    // GET ALL
    public async Task<IEnumerable<LecturerDto>> GetAllAsync()
    {
        var lecturers = await _lecturerRepository.GetAllAsync();

        return lecturers.Select(MapToDto);
    }

    // CREATE
    public async Task<LecturerDto> CreateAsync(CreateLecturerDto lecturerDto)
    {
        var lecturer = new Lecturer
        {
            UserId = lecturerDto.UserId,
            EmployeeNumber = lecturerDto.EmployeeNumber,
            DepartmentId = lecturerDto.DepartmentId
        };

        var createdLecturer = await _lecturerRepository.CreateAsync(lecturer);

        return MapToDto(createdLecturer);
    }

    // UPDATE
    public async Task<bool> UpdateAsync(int id, UpdateLecturerDto lecturerDto)
    {
        var lecturer = await _lecturerRepository.GetByIdAsync(id);

        if (lecturer == null)
            return false;

        lecturer.EmployeeNumber = lecturerDto.EmployeeNumber;
        lecturer.DepartmentId = lecturerDto.DepartmentId;

        await _lecturerRepository.UpdateAsync(lecturer);

        return true;
    }

    // DELETE
    public async Task<bool> DeleteAsync(int id)
    {
        var lecturer = await _lecturerRepository.GetByIdAsync(id);

        if (lecturer == null)
            return false;

        await _lecturerRepository.DeleteAsync(lecturer);

        return true;
    }

    // ENTITY TO DTO MAPPING
    private static LecturerDto MapToDto(Lecturer lecturer)
    {
        return new LecturerDto
        {
            LecturerId = lecturer.LecturerId,
            UserId = lecturer.UserId,
            FirstName = lecturer.User?.FirstName ?? string.Empty,
            LastName = lecturer.User?.LastName ?? string.Empty,
            Email = lecturer.User?.Email ?? string.Empty,
            EmployeeNumber = lecturer.EmployeeNumber,
            DepartmentId = lecturer.DepartmentId,
            DepartmentName = lecturer.Department?.DepartmentName ?? string.Empty
        };
    }
}