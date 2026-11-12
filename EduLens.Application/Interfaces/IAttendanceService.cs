
using EduLens.Application.DTOs;

namespace EduLens.Application.Interfaces;

public interface IAttendanceService
{
    Task<AttendanceDto?> GetByIdAsync(int id);

    Task<IEnumerable<AttendanceDto>> GetAllAsync();

    Task<AttendanceDto> CreateAsync(CreateAttendanceDto attendanceDto);

    Task<bool> UpdateAsync(int id, UpdateAttendanceDto attendanceDto);

    Task<bool> DeleteAsync(int id);
}
