
using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;
using EduLens.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EduLens.Infrastructure.Data.Repositories;

public class AttendanceRepository : IAttendanceRepository
{
    private readonly EduLensDbContext _context;

    public AttendanceRepository(EduLensDbContext context)
    {
        _context = context;
    }

    public async Task<Attendance?> GetByIdAsync(int id)
    {
        return await _context.Attendances
            .Include(a => a.Enrollment)
                .ThenInclude(e => e.Student)
                    .ThenInclude(s => s.User)
            .Include(a => a.Enrollment)
                .ThenInclude(e => e.Course)
            .FirstOrDefaultAsync(a => a.AttendanceId == id);
    }

    public async Task<IEnumerable<Attendance>> GetAllAsync()
    {
        return await _context.Attendances
            .Include(a => a.Enrollment)
                .ThenInclude(e => e.Student)
            .Include(a => a.Enrollment)
                .ThenInclude(e => e.Course)
            .ToListAsync();
    }

    public async Task<Attendance> CreateAsync(Attendance attendance)
    {
        await _context.Attendances.AddAsync(attendance);
        await _context.SaveChangesAsync();

        return await GetByIdAsync(attendance.AttendanceId) ?? attendance;
    }

    public async Task UpdateAsync(Attendance attendance)
    {
        var existingAttendance = await _context.Attendances
            .FirstOrDefaultAsync(a => a.AttendanceId == attendance.AttendanceId);

        if (existingAttendance == null)
            throw new KeyNotFoundException("Attendance record not found.");

        existingAttendance.EnrollmentId = attendance.EnrollmentId;
        existingAttendance.Date = attendance.Date;
        existingAttendance.IsPresent = attendance.IsPresent;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Attendance attendance)
    {
        _context.Attendances.Remove(attendance);
        await _context.SaveChangesAsync();
    }
}
