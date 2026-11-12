
using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;

namespace EduLens.Application.Services;

public class AttendanceService : IAttendanceService
{
    private readonly IAttendanceRepository _attendanceRepository;

    public AttendanceService(IAttendanceRepository attendanceRepository)
    {
        _attendanceRepository = attendanceRepository;
    }

    public async Task<AttendanceDto?> GetByIdAsync(int id)
    {
        var attendance = await _attendanceRepository.GetByIdAsync(id);

        if (attendance == null)
            return null;

        return MapToDto(attendance);
    }

    public async Task<IEnumerable<AttendanceDto>> GetAllAsync()
    {
        var attendanceRecords = await _attendanceRepository.GetAllAsync();

        return attendanceRecords.Select(MapToDto);
    }

    public async Task<AttendanceDto> CreateAsync(CreateAttendanceDto attendanceDto)
    {
        var attendance = new Attendance
        {
            EnrollmentId = attendanceDto.EnrollmentId,
            Date = attendanceDto.Date,
            IsPresent = attendanceDto.IsPresent
        };

        var createdAttendance = await _attendanceRepository.CreateAsync(attendance);

        return MapToDto(createdAttendance);
    }

    public async Task<bool> UpdateAsync(int id, UpdateAttendanceDto attendanceDto)
    {
        var attendance = await _attendanceRepository.GetByIdAsync(id);

        if (attendance == null)
            return false;

        attendance.EnrollmentId = attendanceDto.EnrollmentId;
        attendance.Date = attendanceDto.Date;
        attendance.IsPresent = attendanceDto.IsPresent;

        await _attendanceRepository.UpdateAsync(attendance);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var attendance = await _attendanceRepository.GetByIdAsync(id);

        if (attendance == null)
            return false;

        await _attendanceRepository.DeleteAsync(attendance);

        return true;
    }

    private static AttendanceDto MapToDto(Attendance attendance)
    {
        return new AttendanceDto
        {
            AttendanceId = attendance.AttendanceId,
            EnrollmentId = attendance.EnrollmentId,
            StudentNumber = attendance.Enrollment?.Student?.StudentNumber ?? string.Empty,
            CourseCode = attendance.Enrollment?.Course?.CourseCode ?? string.Empty,
            Date = attendance.Date,
            IsPresent = attendance.IsPresent
        };
    }
}
