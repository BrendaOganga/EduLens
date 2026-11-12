using EduLens.Application.DTOs;

namespace EduLens.Application.Interfaces;

public interface IDepartmentService
{
    Task<DepartmentDto?> GetByIdAsync(int departmentId);

    Task<IEnumerable<DepartmentDto>> GetAllAsync();

    Task<DepartmentDto> CreateAsync(CreateDepartmentDto departmentDto);

    Task<DepartmentDto?> UpdateAsync(int departmentId, UpdateDepartmentDto departmentDto);

    Task<bool> DeleteAsync(int departmentId);
}