
using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;
using EduLens.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace EduLens.Infrastructure.Data.Repositories;

public class CourseRepository : ICourseRepository
{
    private readonly EduLensDbContext _context;

    public CourseRepository(EduLensDbContext context)
    {
        _context = context;
    }

    public async Task<Course?> GetByIdAsync(int id)
    {
        return await _context.Courses
            .Include(c => c.Department)
            .FirstOrDefaultAsync(c => c.CourseId == id);
    }

    public async Task<IEnumerable<Course>> GetAllAsync()
    {
        return await _context.Courses
            .Include(c => c.Department)
            .ToListAsync();
    }

    public async Task<Course> CreateAsync(Course course)
    {
        await _context.Courses.AddAsync(course);
        await _context.SaveChangesAsync();

        return await _context.Courses
            .Include(c => c.Department)
            .FirstAsync(c => c.CourseId == course.CourseId);
    }

    public async Task<Course?> UpdateAsync(int id, Course course)
    {
        var existingCourse = await _context.Courses
            .FirstOrDefaultAsync(c => c.CourseId == id);

        if (existingCourse == null)
        {
            return null;
        }

        existingCourse.CourseCode = course.CourseCode;
        existingCourse.CourseName = course.CourseName;
        existingCourse.DepartmentId = course.DepartmentId;
        existingCourse.Credits = course.Credits;

        await _context.SaveChangesAsync();

        return await _context.Courses
            .Include(c => c.Department)
            .FirstOrDefaultAsync(c => c.CourseId == id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var course = await _context.Courses
            .FirstOrDefaultAsync(c => c.CourseId == id);

        if (course == null)
        {
            return false;
        }

        _context.Courses.Remove(course);
        await _context.SaveChangesAsync();

        return true;
    }
}
