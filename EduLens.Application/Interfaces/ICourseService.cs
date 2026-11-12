
using EduLens.Application.DTOs;

namespace EduLens.Application.Interfaces;

public interface ICourseService
{
    Task<CourseDto?> GetByIdAsync(int id);

    Task<IEnumerable<CourseDto>> GetAllAsync();

    Task<CourseDto> CreateAsync(CreateCourseDto courseDto);

    Task<CourseDto?> UpdateAsync(int id, UpdateCourseDto courseDto);

    Task<bool> DeleteAsync(int id);
}
