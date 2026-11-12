
using EduLens.Domain.Entities;

namespace EduLens.Application.Interfaces;

public interface IAttendanceRepository
{
    Task<Attendance?> GetByIdAsync(int id);

    Task<IEnumerable<Attendance>> GetAllAsync();

    Task<Attendance> CreateAsync(Attendance attendance);

    Task UpdateAsync(Attendance attendance);

    Task DeleteAsync(Attendance attendance);
}
