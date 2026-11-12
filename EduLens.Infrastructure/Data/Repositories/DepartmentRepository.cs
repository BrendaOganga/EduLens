using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduLens.Infrastructure.Data.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly EduLensDbContext _context;

    public DepartmentRepository(EduLensDbContext context)
    {
        _context = context;
    }

    public async Task<Department?> GetByIdAsync(int departmentId)
    {
        return await _context.Departments
            .FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
    }

    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        return await _context.Departments.ToListAsync();
    }

    public async Task<Department> CreateAsync(Department department)
    {
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();

        return department;
    }

    public async Task<Department?> UpdateAsync(Department department)
    {
        var existingDepartment = await _context.Departments
            .FirstOrDefaultAsync(d => d.DepartmentId == department.DepartmentId);

        if (existingDepartment == null)
            return null;

        existingDepartment.DepartmentName = department.DepartmentName;

        await _context.SaveChangesAsync();

        return existingDepartment;
    }

    public async Task<bool> DeleteAsync(int departmentId)
    {
        var department = await _context.Departments
            .FirstOrDefaultAsync(d => d.DepartmentId == departmentId);

        if (department == null)
            return false;

        _context.Departments.Remove(department);
        await _context.SaveChangesAsync();

        return true;
    }
}