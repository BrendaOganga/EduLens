
using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;

namespace EduLens.Application.Services;

public class AssessmentService : IAssessmentService
{
    private readonly IAssessmentRepository _assessmentRepository;

    public AssessmentService(IAssessmentRepository assessmentRepository)
    {
        _assessmentRepository = assessmentRepository;
    }

    public async Task<AssessmentDto?> GetByIdAsync(int id)
    {
        var assessment = await _assessmentRepository.GetByIdAsync(id);

        if (assessment == null)
            return null;

        return new AssessmentDto
        {
            AssessmentId = assessment.AssessmentId,
            EnrollmentId = assessment.EnrollmentId,
            StudentNumber = assessment.Enrollment.Student.StudentNumber,
            CourseCode = assessment.Enrollment.Course.CourseCode,
            AssessmentType = assessment.AssessmentType,
            Score = assessment.Score,
            MaximumScore = assessment.MaximumScore,
            AssessmentDate = assessment.AssessmentDate
        };
    }

    public async Task<IEnumerable<AssessmentDto>> GetAllAsync()
    {
        var assessments = await _assessmentRepository.GetAllAsync();

        return assessments.Select(assessment => new AssessmentDto
        {
            AssessmentId = assessment.AssessmentId,
            EnrollmentId = assessment.EnrollmentId,
            StudentNumber = assessment.Enrollment.Student.StudentNumber,
            CourseCode = assessment.Enrollment.Course.CourseCode,
            AssessmentType = assessment.AssessmentType,
            Score = assessment.Score,
            MaximumScore = assessment.MaximumScore,
            AssessmentDate = assessment.AssessmentDate
        });
    }

    public async Task<AssessmentDto> CreateAsync(CreateAssessmentDto assessmentDto)
    {
        var assessment = new Assessment
        {
            EnrollmentId = assessmentDto.EnrollmentId,
            AssessmentType = assessmentDto.AssessmentType,
            Score = assessmentDto.Score,
            MaximumScore = assessmentDto.MaximumScore,
            AssessmentDate = assessmentDto.AssessmentDate
        };

        var createdAssessment = await _assessmentRepository.CreateAsync(assessment);

        return new AssessmentDto
        {
            AssessmentId = createdAssessment.AssessmentId,
            EnrollmentId = createdAssessment.EnrollmentId,
            StudentNumber = createdAssessment.Enrollment.Student.StudentNumber,
            CourseCode = createdAssessment.Enrollment.Course.CourseCode,
            AssessmentType = createdAssessment.AssessmentType,
            Score = createdAssessment.Score,
            MaximumScore = createdAssessment.MaximumScore,
            AssessmentDate = createdAssessment.AssessmentDate
        };
    }

    public async Task<AssessmentDto?> UpdateAsync(int id, UpdateAssessmentDto assessmentDto)
    {
        var assessment = new Assessment
        {
            EnrollmentId = assessmentDto.EnrollmentId,
            AssessmentType = assessmentDto.AssessmentType,
            Score = assessmentDto.Score,
            MaximumScore = assessmentDto.MaximumScore,
            AssessmentDate = assessmentDto.AssessmentDate
        };

        var updatedAssessment = await _assessmentRepository.UpdateAsync(id, assessment);

        if (updatedAssessment == null)
            return null;

        return new AssessmentDto
        {
            AssessmentId = updatedAssessment.AssessmentId,
            EnrollmentId = updatedAssessment.EnrollmentId,
            StudentNumber = updatedAssessment.Enrollment.Student.StudentNumber,
            CourseCode = updatedAssessment.Enrollment.Course.CourseCode,
            AssessmentType = updatedAssessment.AssessmentType,
            Score = updatedAssessment.Score,
            MaximumScore = updatedAssessment.MaximumScore,
            AssessmentDate = updatedAssessment.AssessmentDate
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _assessmentRepository.DeleteAsync(id);
    }
}
