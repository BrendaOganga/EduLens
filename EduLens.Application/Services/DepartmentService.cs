using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;

namespace EduLens.Application.Services;

public class DepartmentService : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;

    public DepartmentService(IDepartmentRepository departmentRepository)
    {
        _departmentRepository = departmentRepository;
    }

    public async Task<DepartmentDto?> GetByIdAsync(int departmentId)
    {
        var department = await _departmentRepository.GetByIdAsync(departmentId);

        if (department == null)
            return null;

        return MapToDto(department);
    }

    public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
    {
        var departments = await _departmentRepository.GetAllAsync();

        return departments.Select(MapToDto);
    }

    public async Task<DepartmentDto> CreateAsync(CreateDepartmentDto departmentDto)
    {
        var department = new Department
        {
            DepartmentName = departmentDto.DepartmentName
        };

        var createdDepartment = await _departmentRepository.CreateAsync(department);

        return MapToDto(createdDepartment);
    }

    public async Task<DepartmentDto?> UpdateAsync(int departmentId, UpdateDepartmentDto departmentDto)
    {
        var department = await _departmentRepository.GetByIdAsync(departmentId);

        if (department == null)
            return null;

        department.DepartmentName = departmentDto.DepartmentName;

        var updatedDepartment = await _departmentRepository.UpdateAsync(department);

        if (updatedDepartment == null)
            return null;

        return MapToDto(updatedDepartment);
    }

    public async Task<bool> DeleteAsync(int departmentId)
    {
        return await _departmentRepository.DeleteAsync(departmentId);
    }

    private static DepartmentDto MapToDto(Department department)
    {
        return new DepartmentDto
        {
            DepartmentId = department.DepartmentId,
            DepartmentName = department.DepartmentName
        };
    }
}