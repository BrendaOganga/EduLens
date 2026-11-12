using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduLens.Infrastructure.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly EduLensDbContext _context;

    public UserRepository(EduLensDbContext context)
    {
        _context = context;
    }

    // GET BY ID
    public async Task<User?> GetByIdAsync(int id)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.UserId == id);
    }

    // GET ALL
    public async Task<IEnumerable<User>> GetAllAsync()
    {
        return await _context.Users
            .ToListAsync();
    }

    // GET BY EMAIL
    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    // CREATE
    public async Task<User> CreateAsync(User user)
    {
        await _context.Users.AddAsync(user);

        await _context.SaveChangesAsync();

        return user;
    }

    // UPDATE
    public async Task UpdateAsync(User user)
    {
        var existingUser = await _context.Users
            .FirstOrDefaultAsync(u => u.UserId == user.UserId);

        if (existingUser == null)
            throw new KeyNotFoundException("User not found.");

        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Email = user.Email;
        existingUser.Role = user.Role;

        await _context.SaveChangesAsync();
    }

    // DELETE
    public async Task DeleteAsync(User user)
    {
        _context.Users.Remove(user);

        await _context.SaveChangesAsync();
    }
}