
using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduLens.Infrastructure.Data.Repositories;

public class AssessmentRepository : IAssessmentRepository
{
    private readonly EduLensDbContext _context;

    public AssessmentRepository(EduLensDbContext context)
    {
        _context = context;
    }

    public async Task<Assessment?> GetByIdAsync(int id)
    {
        return await _context.Assessments
            .Include(a => a.Enrollment)
                .ThenInclude(e => e.Student)
            .Include(a => a.Enrollment)
                .ThenInclude(e => e.Course)
            .FirstOrDefaultAsync(a => a.AssessmentId == id);
    }

    public async Task<IEnumerable<Assessment>> GetAllAsync()
    {
        return await _context.Assessments
            .Include(a => a.Enrollment)
                .ThenInclude(e => e.Student)
            .Include(a => a.Enrollment)
                .ThenInclude(e => e.Course)
            .ToListAsync();
    }

    public async Task<Assessment> CreateAsync(Assessment assessment)
    {
        await _context.Assessments.AddAsync(assessment);
        await _context.SaveChangesAsync();

        return await _context.Assessments
            .Include(a => a.Enrollment)
                .ThenInclude(e => e.Student)
            .Include(a => a.Enrollment)
                .ThenInclude(e => e.Course)
            .FirstAsync(a => a.AssessmentId == assessment.AssessmentId);
    }

    public async Task<Assessment?> UpdateAsync(int id, Assessment assessment)
    {
        var existingAssessment = await _context.Assessments
            .FirstOrDefaultAsync(a => a.AssessmentId == id);

        if (existingAssessment == null)
        {
            return null;
        }

        existingAssessment.EnrollmentId = assessment.EnrollmentId;
        existingAssessment.AssessmentType = assessment.AssessmentType;
        existingAssessment.Score = assessment.Score;
        existingAssessment.MaximumScore = assessment.MaximumScore;
        existingAssessment.AssessmentDate = assessment.AssessmentDate;

        await _context.SaveChangesAsync();

        return await _context.Assessments
            .Include(a => a.Enrollment)
                .ThenInclude(e => e.Student)
            .Include(a => a.Enrollment)
                .ThenInclude(e => e.Course)
            .FirstOrDefaultAsync(a => a.AssessmentId == id);
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var assessment = await _context.Assessments
            .FirstOrDefaultAsync(a => a.AssessmentId == id);

        if (assessment == null)
        {
            return false;
        }

        _context.Assessments.Remove(assessment);
        await _context.SaveChangesAsync();

        return true;
    }
}
