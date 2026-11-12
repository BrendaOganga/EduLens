using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduLens.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController : ControllerBase
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    // GET: api/students
    [HttpGet]
    public async Task<ActionResult<IEnumerable<StudentDto>>> GetAll()
    {
        var students = await _studentService.GetAllAsync();

        return Ok(students);
    }

    // GET: api/students/5
    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDto>> GetById(int id)
    {
        var student = await _studentService.GetByIdAsync(id);

        if (student == null)
        {
            return NotFound();
        }

        return Ok(student);
    }

    // POST: api/students
    [HttpPost]
    public async Task<ActionResult<StudentDto>> Create(
        CreateStudentDto studentDto)
    {
        var student = await _studentService.CreateAsync(studentDto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = student.StudentId },
            student);
    }

    // PUT: api/students/5
    [HttpPut("{id}")]
    public async Task<ActionResult<StudentDto>> Update(
        int id,
        UpdateStudentDto studentDto)
    {
        var updatedStudent = await _studentService.UpdateAsync(
            id,
            studentDto);

        if (updatedStudent == null)
        {
            return NotFound();
        }

        return Ok(updatedStudent);
    }

    // DELETE: api/students/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _studentService.DeleteAsync(id);

        if (!deleted)
        {
            return NotFound();
        }

        return NoContent();
    }
}
