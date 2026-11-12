using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduLens.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LecturersController : ControllerBase
{
    private readonly ILecturerService _lecturerService;

    public LecturersController(ILecturerService lecturerService)
    {
        _lecturerService = lecturerService;
    }

    // GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var lecturers = await _lecturerService.GetAllAsync();

        return Ok(lecturers);
    }

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var lecturer = await _lecturerService.GetByIdAsync(id);

        if (lecturer == null)
            return NotFound();

        return Ok(lecturer);
    }

    // CREATE
    [HttpPost]
    public async Task<IActionResult> Create(CreateLecturerDto lecturerDto)
    {
        var lecturer = await _lecturerService.CreateAsync(lecturerDto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = lecturer.LecturerId },
            lecturer);
    }

    // UPDATE
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateLecturerDto lecturerDto)
    {
        var updated = await _lecturerService.UpdateAsync(id, lecturerDto);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _lecturerService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}