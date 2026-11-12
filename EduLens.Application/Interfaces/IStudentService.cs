using EduLens.Application.DTOs;

namespace EduLens.Application.Interfaces;

public interface IStudentService
{
    Task<StudentDto?> GetByIdAsync(int studentId);

    Task<IEnumerable<StudentDto>> GetAllAsync();

    Task<StudentDto> CreateAsync(CreateStudentDto studentDto);

    Task<StudentDto?> UpdateAsync(
        int studentId,
        UpdateStudentDto studentDto);

    Task<bool> DeleteAsync(int studentId);
}