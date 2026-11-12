
using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduLens.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AssessmentsController : ControllerBase
{
    private readonly IAssessmentService _assessmentService;

    public AssessmentsController(IAssessmentService assessmentService)
    {
        _assessmentService = assessmentService;
    }

    // GET: api/Assessments
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var assessments = await _assessmentService.GetAllAsync();

        return Ok(assessments);
    }

    // GET: api/Assessments/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var assessment = await _assessmentService.GetByIdAsync(id);

        if (assessment == null)
        {
            return NotFound();
        }

        return Ok(assessment);
    }

    // POST: api/Assessments
    [HttpPost]
    public async Task<IActionResult> Create(CreateAssessmentDto assessmentDto)
    {
        var assessment = await _assessmentService.CreateAsync(assessmentDto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = assessment.AssessmentId },
            assessment
        );
    }

    // PUT: api/Assessments/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateAssessmentDto assessmentDto)
    {
        var assessment = await _assessmentService.UpdateAsync(id, assessmentDto);

        if (assessment == null)
        {
            return NotFound();
        }

        return Ok(assessment);
    }

    // DELETE: api/Assessments/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _assessmentService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
