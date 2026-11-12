
using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;

namespace EduLens.Application.Services;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<CourseDto?> GetByIdAsync(int id)
    {
        var course = await _courseRepository.GetByIdAsync(id);

        if (course == null)
        {
            return null;
        }

        return new CourseDto
        {
            CourseId = course.CourseId,
            CourseCode = course.CourseCode,
            CourseName = course.CourseName,
            DepartmentId = course.DepartmentId,
            DepartmentName = course.Department.DepartmentName,
            Credits = course.Credits
        };
    }

    public async Task<IEnumerable<CourseDto>> GetAllAsync()
    {
        var courses = await _courseRepository.GetAllAsync();

        return courses.Select(course => new CourseDto
        {
            CourseId = course.CourseId,
            CourseCode = course.CourseCode,
            CourseName = course.CourseName,
            DepartmentId = course.DepartmentId,
            DepartmentName = course.Department.DepartmentName,
            Credits = course.Credits
        });
    }

    public async Task<CourseDto> CreateAsync(CreateCourseDto courseDto)
    {
        var course = new Course
        {
            CourseCode = courseDto.CourseCode,
            CourseName = courseDto.CourseName,
            DepartmentId = courseDto.DepartmentId,
            Credits = courseDto.Credits
        };

        var createdCourse = await _courseRepository.CreateAsync(course);

        return new CourseDto
        {
            CourseId = createdCourse.CourseId,
            CourseCode = createdCourse.CourseCode,
            CourseName = createdCourse.CourseName,
            DepartmentId = createdCourse.DepartmentId,
            DepartmentName = createdCourse.Department.DepartmentName,
            Credits = createdCourse.Credits
        };
    }

    public async Task<CourseDto?> UpdateAsync(int id, UpdateCourseDto courseDto)
    {
        var course = new Course
        {
            CourseCode = courseDto.CourseCode,
            CourseName = courseDto.CourseName,
            DepartmentId = courseDto.DepartmentId,
            Credits = courseDto.Credits
        };

        var updatedCourse = await _courseRepository.UpdateAsync(id, course);

        if (updatedCourse == null)
        {
            return null;
        }

        return new CourseDto
        {
            CourseId = updatedCourse.CourseId,
            CourseCode = updatedCourse.CourseCode,
            CourseName = updatedCourse.CourseName,
            DepartmentId = updatedCourse.DepartmentId,
            DepartmentName = updatedCourse.Department.DepartmentName,
            Credits = updatedCourse.Credits
        };
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _courseRepository.DeleteAsync(id);
    }
}
