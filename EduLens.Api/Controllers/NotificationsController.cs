
using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EduLens.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NotificationsController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationsController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var notifications = await _notificationService.GetAllAsync();

        return Ok(notifications);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var notification = await _notificationService.GetByIdAsync(id);

        if (notification == null)
            return NotFound();

        return Ok(notification);
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateNotificationDto notificationDto)
    {
        var notification = await _notificationService.CreateAsync(notificationDto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = notification.NotificationId },
            notification);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(
        int id,
        UpdateNotificationDto notificationDto)
    {
        var updated = await _notificationService.UpdateAsync(id, notificationDto);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _notificationService.DeleteAsync(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}
