using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduLens.Infrastructure.Data.Repositories;

public class ProgrammeRepository : IProgrammeRepository
{
    private readonly EduLensDbContext _context;

    public ProgrammeRepository(EduLensDbContext context)
    {
        _context = context;
    }

    public async Task<Programme?> GetByIdAsync(int programmeId)
    {
        return await _context.Programmes
            .Include(p => p.Department)
            .FirstOrDefaultAsync(p => p.ProgrammeId == programmeId);
    }

    public async Task<IEnumerable<Programme>> GetAllAsync()
    {
        return await _context.Programmes
            .Include(p => p.Department)
            .ToListAsync();
    }

    public async Task<Programme> CreateAsync(Programme programme)
    {
        _context.Programmes.Add(programme);
        await _context.SaveChangesAsync();

        return programme;
    }

    public async Task<Programme?> UpdateAsync(Programme programme)
    {
        var existingProgramme = await _context.Programmes
            .FirstOrDefaultAsync(p => p.ProgrammeId == programme.ProgrammeId);

        if (existingProgramme == null)
            return null;

        existingProgramme.ProgrammeName = programme.ProgrammeName;
        existingProgramme.DepartmentId = programme.DepartmentId;

        await _context.SaveChangesAsync();

        return await GetByIdAsync(programme.ProgrammeId);
    }

    public async Task<bool> DeleteAsync(int programmeId)
    {
        var programme = await _context.Programmes
            .FirstOrDefaultAsync(p => p.ProgrammeId == programmeId);

        if (programme == null)
            return false;

        _context.Programmes.Remove(programme);
        await _context.SaveChangesAsync();

        return true;
    }
}