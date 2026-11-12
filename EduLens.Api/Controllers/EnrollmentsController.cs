
using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduLens.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EnrollmentsController : ControllerBase
{
    private readonly IEnrollmentService _enrollmentService;

    public EnrollmentsController(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    // GET: api/Enrollments
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var enrollments = await _enrollmentService.GetAllAsync();

        return Ok(enrollments);
    }

    // GET: api/Enrollments/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var enrollment = await _enrollmentService.GetByIdAsync(id);

        if (enrollment == null)
        {
            return NotFound();
        }

        return Ok(enrollment);
    }

    // POST: api/Enrollments
    [HttpPost]
    public async Task<IActionResult> Create(CreateEnrollmentDto enrollmentDto)
    {
        var enrollment = await _enrollmentService.CreateAsync(enrollmentDto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = enrollment.EnrollmentId },
            enrollment
        );
    }

    // PUT: api/Enrollments/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateEnrollmentDto enrollmentDto)
    {
        var enrollment = await _enrollmentService.UpdateAsync(id, enrollmentDto);

        if (enrollment == null)
        {
            return NotFound();
        }

        return Ok(enrollment);
    }

    // DELETE: api/Enrollments/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _enrollmentService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
