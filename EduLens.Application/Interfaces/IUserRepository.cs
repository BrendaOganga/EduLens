using EduLens.Domain.Entities;

namespace EduLens.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);

    Task<IEnumerable<User>> GetAllAsync();

    Task<User?> GetByEmailAsync(string email);

    Task<User> CreateAsync(User user);

    Task UpdateAsync(User user);

    Task DeleteAsync(User user);
}