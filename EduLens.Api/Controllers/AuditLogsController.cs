using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduLens.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuditLogsController : ControllerBase
{
    private readonly IAuditLogService _auditLogService;

    public AuditLogsController(IAuditLogService auditLogService)
    {
        _auditLogService = auditLogService;
    }

    // GET ALL
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var auditLogs = await _auditLogService.GetAllAsync();

        return Ok(auditLogs);
    }

    // GET BY ID
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var auditLog = await _auditLogService.GetByIdAsync(id);

        if (auditLog == null)
            return NotFound();

        return Ok(auditLog);
    }

    // CREATE
    [HttpPost]
    public async Task<IActionResult> Create(CreateAuditLogDto auditLogDto)
    {
        var auditLog = await _auditLogService.CreateAsync(auditLogDto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = auditLog.AuditLogId },
            auditLog);
    }

    // UPDATE
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateAuditLogDto auditLogDto)
    {
        var updated = await _auditLogService.UpdateAsync(id, auditLogDto);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    // DELETE
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _auditLogService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}