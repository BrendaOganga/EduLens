using EduLens.Domain.Entities;

namespace EduLens.Application.Interfaces;

public interface ILecturerRepository
{
    Task<Lecturer?> GetByIdAsync(int id);

    Task<IEnumerable<Lecturer>> GetAllAsync();

    Task<Lecturer> CreateAsync(Lecturer lecturer);

    Task UpdateAsync(Lecturer lecturer);

    Task DeleteAsync(Lecturer lecturer);
}