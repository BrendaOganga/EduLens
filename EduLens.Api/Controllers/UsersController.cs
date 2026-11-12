using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduLens.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    // GET: api/Users
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();

        return Ok(users);
    }

    // GET: api/Users/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    // POST: api/Users
    [HttpPost]
    public async Task<IActionResult> Create(CreateUserDto userDto)
    {
        try
        {
            var user = await _userService.CreateAsync(userDto);

            return CreatedAtAction(
                nameof(GetById),
                new { id = user.UserId },
                user
            );
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    // PUT: api/Users/1
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, UpdateUserDto userDto)
    {
        try
        {
            var updated = await _userService.UpdateAsync(id, userDto);

            if (!updated)
                return NotFound();

            return NoContent();
        }
        catch (InvalidOperationException ex)
        {
            return Conflict(new { message = ex.Message });
        }
    }

    // DELETE: api/Users/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _userService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}