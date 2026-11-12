using EduLens.Domain.Entities;

namespace EduLens.Application.Interfaces;

public interface ICourseRepository
{
    Task<Course?> GetByIdAsync(int id);

    Task<IEnumerable<Course>> GetAllAsync();

    Task<Course> CreateAsync(Course course);

    Task<Course?> UpdateAsync(int id, Course course);

    Task<bool> DeleteAsync(int id);
}