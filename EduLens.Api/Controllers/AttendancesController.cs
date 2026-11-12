
using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduLens.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AttendancesController : ControllerBase
{
    private readonly IAttendanceService _attendanceService;

    public AttendancesController(IAttendanceService attendanceService)
    {
        _attendanceService = attendanceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var attendanceRecords = await _attendanceService.GetAllAsync();
        return Ok(attendanceRecords);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var attendance = await _attendanceService.GetByIdAsync(id);

        if (attendance == null)
            return NotFound();

        return Ok(attendance);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateAttendanceDto attendanceDto)
    {
        var attendance = await _attendanceService.CreateAsync(attendanceDto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = attendance.AttendanceId },
            attendance);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateAttendanceDto attendanceDto)
    {
        var updated = await _attendanceService.UpdateAsync(id, attendanceDto);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _attendanceService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
