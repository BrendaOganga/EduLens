using EduLens.Domain.Entities;

namespace EduLens.Application.Interfaces;

public interface IDepartmentRepository
{
    Task<Department?> GetByIdAsync(int departmentId);

    Task<IEnumerable<Department>> GetAllAsync();

    Task<Department> CreateAsync(Department department);

    Task<Department?> UpdateAsync(Department department);

    Task<bool> DeleteAsync(int departmentId);
}