
using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;

namespace EduLens.Application.Services;

public class NotificationService : INotificationService
{
    private readonly INotificationRepository _notificationRepository;

    public NotificationService(INotificationRepository notificationRepository)
    {
        _notificationRepository = notificationRepository;
    }

    public async Task<NotificationDto?> GetByIdAsync(int id)
    {
        var notification = await _notificationRepository.GetByIdAsync(id);

        if (notification == null)
            return null;

        return MapToDto(notification);
    }

    public async Task<IEnumerable<NotificationDto>> GetAllAsync()
    {
        var notifications = await _notificationRepository.GetAllAsync();

        return notifications.Select(MapToDto);
    }

    public async Task<NotificationDto> CreateAsync(CreateNotificationDto notificationDto)
    {
        var notification = new Notification
        {
            UserId = notificationDto.UserId,
            Title = notificationDto.Title,
            Message = notificationDto.Message,
            IsRead = false,
            CreatedAt = DateTime.UtcNow
        };

        var createdNotification = await _notificationRepository.CreateAsync(notification);

        return MapToDto(createdNotification);
    }

    public async Task<bool> UpdateAsync(int id, UpdateNotificationDto notificationDto)
    {
        var notification = await _notificationRepository.GetByIdAsync(id);

        if (notification == null)
            return false;

        notification.Title = notificationDto.Title;
        notification.Message = notificationDto.Message;
        notification.IsRead = notificationDto.IsRead;

        await _notificationRepository.UpdateAsync(notification);

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var notification = await _notificationRepository.GetByIdAsync(id);

        if (notification == null)
            return false;

        await _notificationRepository.DeleteAsync(notification);

        return true;
    }

    private static NotificationDto MapToDto(Notification notification)
    {
        return new NotificationDto
        {
            NotificationId = notification.NotificationId,
            UserId = notification.UserId,
            FirstName = notification.User?.FirstName ?? string.Empty,
            LastName = notification.User?.LastName ?? string.Empty,
            Title = notification.Title,
            Message = notification.Message,
            IsRead = notification.IsRead,
            CreatedAt = notification.CreatedAt
        };
    }
}
