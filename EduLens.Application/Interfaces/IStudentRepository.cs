using EduLens.Domain.Entities;

namespace EduLens.Application.Interfaces;

public interface IStudentRepository
{
    Task<Student?> GetByIdAsync(int studentId);

    Task<IEnumerable<Student>> GetAllAsync();

    Task<Student> CreateAsync(Student student);

    Task<Student?> UpdateAsync(Student student);

    Task<bool> DeleteAsync(int studentId);
}