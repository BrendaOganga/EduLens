
using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduLens.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CoursesController : ControllerBase
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    // GET: api/Courses
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var courses = await _courseService.GetAllAsync();

        return Ok(courses);
    }

    // GET: api/Courses/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var course = await _courseService.GetByIdAsync(id);

        if (course == null)
        {
            return NotFound();
        }

        return Ok(course);
    }

    // POST: api/Courses
    [HttpPost]
    public async Task<IActionResult> Create(CreateCourseDto courseDto)
    {
        var course = await _courseService.CreateAsync(courseDto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = course.CourseId },
            course
        );
    }

    // PUT: api/Courses/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateCourseDto courseDto)
    {
        var course = await _courseService.UpdateAsync(id, courseDto);

        if (course == null)
        {
            return NotFound();
        }

        return Ok(course);
    }

    // DELETE: api/Courses/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _courseService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
