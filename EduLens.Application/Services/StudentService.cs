using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;
using EduLens.Domain.Enums;

namespace EduLens.Application.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<StudentDto?> GetByIdAsync(int studentId)
    {
        var student = await _studentRepository.GetByIdAsync(studentId);

        if (student == null)
        {
            return null;
        }

        return MapToDto(student);
    }

    public async Task<IEnumerable<StudentDto>> GetAllAsync()
    {
        var students = await _studentRepository.GetAllAsync();

        return students.Select(MapToDto);
    }

    public async Task<StudentDto> CreateAsync(CreateStudentDto studentDto)
    {
        var user = new User
        {
            FirstName = studentDto.FirstName,
            LastName = studentDto.LastName,
            Email = studentDto.Email,
            PasswordHash = "TEMPORARY",
            Role = UserRole.Student,
            CreatedAt = DateTime.UtcNow
        };

        var student = new Student
        {
            StudentNumber = studentDto.StudentNumber,
            ProgrammeId = studentDto.ProgrammeId,
            YearOfStudy = studentDto.YearOfStudy,
            User = user
        };

        var createdStudent = await _studentRepository.CreateAsync(student);

        return MapToDto(createdStudent);
    }

    public async Task<StudentDto?> UpdateAsync(
        int studentId,
        UpdateStudentDto studentDto)
    {
        var student = await _studentRepository.GetByIdAsync(studentId);

        if (student == null)
        {
            return null;
        }

        student.StudentNumber = studentDto.StudentNumber;
        student.ProgrammeId = studentDto.ProgrammeId;
        student.YearOfStudy = studentDto.YearOfStudy;

        student.User.FirstName = studentDto.FirstName;
        student.User.LastName = studentDto.LastName;
        student.User.Email = studentDto.Email;

        var updatedStudent = await _studentRepository.UpdateAsync(student);

        if (updatedStudent == null)
        {
            return null;
        }

        return MapToDto(updatedStudent);
    }

    public async Task<bool> DeleteAsync(int studentId)
    {
        return await _studentRepository.DeleteAsync(studentId);
    }

    private static StudentDto MapToDto(Student student)
    {
        return new StudentDto
        {
            StudentId = student.StudentId,
            StudentNumber = student.StudentNumber,
            FirstName = student.User.FirstName,
            LastName = student.User.LastName,
            Email = student.User.Email,
            ProgrammeName = student.Programme.ProgrammeName,
            YearOfStudy = student.YearOfStudy
        };
    }
}