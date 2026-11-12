using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduLens.Infrastructure.Data.Repositories;

public class StudentRepository : IStudentRepository
{
    private readonly EduLensDbContext _context;

    public StudentRepository(EduLensDbContext context)
    {
        _context = context;
    }

    public async Task<Student?> GetByIdAsync(int studentId)
    {
        return await _context.Students
            .Include(s => s.User)
            .Include(s => s.Programme)
            .FirstOrDefaultAsync(s => s.StudentId == studentId);
    }

    public async Task<IEnumerable<Student>> GetAllAsync()
    {
        return await _context.Students
            .Include(s => s.User)
            .Include(s => s.Programme)
            .ToListAsync();
    }

    public async Task<Student> CreateAsync(Student student)
    {
        _context.Students.Add(student);

        await _context.SaveChangesAsync();

        return student;
    }

    public async Task<Student?> UpdateAsync(Student student)
    {
        var existingStudent = await _context.Students
            .Include(s => s.User)
            .FirstOrDefaultAsync(s => s.StudentId == student.StudentId);

        if (existingStudent == null)
        {
            return null;
        }

        existingStudent.StudentNumber = student.StudentNumber;
        existingStudent.ProgrammeId = student.ProgrammeId;
        existingStudent.YearOfStudy = student.YearOfStudy;

        existingStudent.User.FirstName = student.User.FirstName;
        existingStudent.User.LastName = student.User.LastName;
        existingStudent.User.Email = student.User.Email;

        await _context.SaveChangesAsync();

        return existingStudent;
    }

    public async Task<bool> DeleteAsync(int studentId)
    {
        var student = await _context.Students
            .FirstOrDefaultAsync(s => s.StudentId == studentId);

        if (student == null)
        {
            return false;
        }

        _context.Students.Remove(student);

        await _context.SaveChangesAsync();

        return true;
    }
}