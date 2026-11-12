using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduLens.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProgrammesController : ControllerBase
{
    private readonly IProgrammeService _programmeService;

    public ProgrammesController(IProgrammeService programmeService)
    {
        _programmeService = programmeService;
    }

    // GET: api/programmes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProgrammeDto>>> GetAll()
    {
        var programmes = await _programmeService.GetAllAsync();

        return Ok(programmes);
    }

    // GET: api/programmes/1
    [HttpGet("{id}")]
    public async Task<ActionResult<ProgrammeDto>> GetById(int id)
    {
        var programme = await _programmeService.GetByIdAsync(id);

        if (programme == null)
            return NotFound();

        return Ok(programme);
    }

    // POST: api/programmes
    [HttpPost]
    public async Task<ActionResult<ProgrammeDto>> Create(
        CreateProgrammeDto programmeDto)
    {
        var programme = await _programmeService.CreateAsync(programmeDto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = programme.ProgrammeId },
            programme);
    }

    // PUT: api/programmes/1
    [HttpPut("{id}")]
    public async Task<ActionResult<ProgrammeDto>> Update(
        int id, UpdateProgrammeDto programmeDto)
    {
        var updatedProgramme = await _programmeService.UpdateAsync(id, programmeDto);

        if (updatedProgramme == null)
            return NotFound();

        return Ok(updatedProgramme);
    }

    // DELETE: api/programmes/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _programmeService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}