using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduLens.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentsController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }

    // GET: api/departments
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetAll()
    {
        var departments = await _departmentService.GetAllAsync();

        return Ok(departments);
    }

    // GET: api/departments/1
    [HttpGet("{id}")]
    public async Task<ActionResult<DepartmentDto>> GetById(int id)
    {
        var department = await _departmentService.GetByIdAsync(id);

        if (department == null)
            return NotFound();

        return Ok(department);
    }

    // POST: api/departments
    [HttpPost]
    public async Task<ActionResult<DepartmentDto>> Create(CreateDepartmentDto departmentDto)
    {
        var department = await _departmentService.CreateAsync(departmentDto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = department.DepartmentId },
            department);
    }

    // PUT: api/departments/1
    [HttpPut("{id}")]
    public async Task<ActionResult<DepartmentDto>> Update(
        int id, UpdateDepartmentDto departmentDto)
    {
        var updatedDepartment = await _departmentService.UpdateAsync(id, departmentDto);

        if (updatedDepartment == null)
            return NotFound();

        return Ok(updatedDepartment);
    }

    // DELETE: api/departments/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _departmentService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}