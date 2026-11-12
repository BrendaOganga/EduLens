
using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;

namespace EduLens.Application.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _enrollmentRepository;

    public EnrollmentService(IEnrollmentRepository enrollmentRepository)
    {
        _enrollmentRepository = enrollmentRepository;
    }

    public async Task<EnrollmentDto?> GetByIdAsync(int id)
    {
        var enrollment = await _enrollmentRepository.GetByIdAsync(id);

        if (enrollment == null)
            return null;

        return new EnrollmentDto
        {
            EnrollmentId = enrollment.EnrollmentId,
            StudentId = enrollment.StudentId,
            StudentNumber = enrollment.Student.StudentNumber,
            CourseId = enrollment.CourseId,
            CourseCode = enrollment.Course.CourseCode,
            CourseName = enrollment.Course.CourseName,
            Semester = enrollment.Semester,
            AcademicYear = enrollment.AcademicYear
        };
    }

    public async Task<IEnumerable<EnrollmentDto>> GetAllAsync()
    {
        var enrollments = await _enrollmentRepository.GetAllAsync();

        return enrollments.Select(enrollment => new EnrollmentDto
        {
            EnrollmentId = enrollment.EnrollmentId,
            StudentId = enrollment.StudentId,
            StudentNumber = enrollment.Student.StudentNumber,
            CourseId = enrollment.CourseId,
            CourseCode = enrollment.Course.CourseCode,
            CourseName = enrollment.Course.CourseName,
            Semester = enrollment.Semester,
            AcademicYear = enrollment.AcademicYear
        });
    }

    public async Task<EnrollmentDto> CreateAsync(CreateEnrollmentDto enrollmentDto)
    {
        var enrollment = new Enrollment
        {
            StudentId = enrollmentDto.StudentId,
            CourseId = enrollmentDto.CourseId,
            Semester = enrollmentDto.Semester,
            AcademicYear = enrollmentDto.AcademicYear
        };

        var createdEnrollment = await _enrollmentRepository.CreateAsync(enrollment);

        return new EnrollmentDto
        {
            EnrollmentId = createdEnrollment.EnrollmentId,
            StudentId = createdEnrollment.StudentId,
            StudentNumber = createdEnrollment.Student.StudentNumber,
            CourseId = createdEnrollment.CourseId,
            CourseCode = createdEnrollment.Course.CourseCode,
            CourseName = createdEnrollment.Course.CourseName,
            Semester = createdEnrollment.Semester,
            AcademicYear = createdEnrollment.AcademicYear
        };
    }

    public async Task<EnrollmentDto?> UpdateAsync(int id, UpdateEnrollmentDto enrollmentDto)
    {
        var enrollment = new Enrollment
        {
            StudentId = enrollmentDto.StudentId,
            CourseId = enrollmentDto.CourseId,
            Semester = enrollmentDto.Semester,
            AcademicYear = enrollmentDto.AcademicYear
        };

        var updatedEnrollment = await _enrollmentRepository.UpdateAsync(id, enrollment);

        if (updatedEnrollment == null)
            return null;

        return new EnrollmentDto
        {
            EnrollmentId = updatedEnrollment.EnrollmentId,
            StudentId = updatedEnrollment.StudentId,
            StudentNumber = updatedEnrollment.Student.StudentNumber,
            CourseId = updatedEnrollment.CourseId,
            CourseCode = updatedEnrollment.Course.CourseCode,
            CourseName = updatedEnrollment.Course.CourseName,
            Semester = updatedEnrollment.Semester,
            AcademicYear = updatedEnrollment.AcademicYear
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _enrollmentRepository.DeleteAsync(id);
    }
}
