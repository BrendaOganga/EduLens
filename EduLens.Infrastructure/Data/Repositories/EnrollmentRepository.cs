
using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduLens.Infrastructure.Data.Repositories;

public class EnrollmentRepository : IEnrollmentRepository
{
    private readonly EduLensDbContext _context;

    public EnrollmentRepository(EduLensDbContext context)
    {
        _context = context;
    }

    public async Task<Enrollment?> GetByIdAsync(int id)
    {
        return await _context.Enrollments
            .Include(e => e.Student)
            .ThenInclude(s => s.User)
            .Include(e => e.Course)
            .FirstOrDefaultAsync(e => e.EnrollmentId == id);
    }

    public async Task<IEnumerable<Enrollment>> GetAllAsync()
    {
        return await _context.Enrollments
            .Include(e => e.Student)
            .ThenInclude(s => s.User)
            .Include(e => e.Course)
            .ToListAsync();
    }

    public async Task<Enrollment> CreateAsync(Enrollment enrollment)
    {
        await _context.Enrollments.AddAsync(enrollment);
        await _context.SaveChangesAsync();

        return await _context.Enrollments
            .Include(e => e.Student)
            .ThenInclude(s => s.User)
            .Include(e => e.Course)
            .FirstAsync(e => e.EnrollmentId == enrollment.EnrollmentId);
    }

    public async Task<Enrollment?> UpdateAsync(int id, Enrollment enrollment)
    {
        var existingEnrollment = await _context.Enrollments
            .FirstOrDefaultAsync(e => e.EnrollmentId == id);

        if (existingEnrollment == null)
        {
            return null;
        }

        existingEnrollment.StudentId = enrollment.StudentId;
        existingEnrollment.CourseId = enrollment.CourseId;
        existingEnrollment.Semester = enrollment.Semester;
        existingEnrollment.AcademicYear = enrollment.AcademicYear;

        await _context.SaveChangesAsync();

        return await _context.Enrollments
            .Include(e => e.Student)
            .ThenInclude(s => s.User)
            .Include(e => e.Course)
            .FirstOrDefaultAsync(e => e.EnrollmentId == id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var enrollment = await _context.Enrollments
            .FirstOrDefaultAsync(e => e.EnrollmentId == id);

        if (enrollment == null)
        {
            return false;
        }

        _context.Enrollments.Remove(enrollment);
        await _context.SaveChangesAsync();

        return true;
    }
}
