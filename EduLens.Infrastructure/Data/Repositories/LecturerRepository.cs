using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduLens.Infrastructure.Data.Repositories;

public class LecturerRepository : ILecturerRepository
{
    private readonly EduLensDbContext _context;

    public LecturerRepository(EduLensDbContext context)
    {
        _context = context;
    }

    // GET BY ID
    public async Task<Lecturer?> GetByIdAsync(int id)
    {
        return await _context.Lecturers
            .Include(l => l.User)
            .Include(l => l.Department)
            .FirstOrDefaultAsync(l => l.LecturerId == id);
    }

    // GET ALL
    public async Task<IEnumerable<Lecturer>> GetAllAsync()
    {
        return await _context.Lecturers
            .Include(l => l.User)
            .Include(l => l.Department)
            .ToListAsync();
    }

    // CREATE
    public async Task<Lecturer> CreateAsync(Lecturer lecturer)
    {
        await _context.Lecturers.AddAsync(lecturer);

        await _context.SaveChangesAsync();

        return await GetByIdAsync(lecturer.LecturerId) ?? lecturer;
    }

    // UPDATE
    public async Task UpdateAsync(Lecturer lecturer)
    {
        var existingLecturer = await _context.Lecturers
            .FirstOrDefaultAsync(l => l.LecturerId == lecturer.LecturerId);

        if (existingLecturer == null)
            throw new KeyNotFoundException("Lecturer not found.");

        existingLecturer.EmployeeNumber = lecturer.EmployeeNumber;
        existingLecturer.DepartmentId = lecturer.DepartmentId;

        await _context.SaveChangesAsync();
    }

    // DELETE
    public async Task DeleteAsync(Lecturer lecturer)
    {
        _context.Lecturers.Remove(lecturer);

        await _context.SaveChangesAsync();
    }
}