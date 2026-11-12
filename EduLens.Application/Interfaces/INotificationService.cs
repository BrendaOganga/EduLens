
using EduLens.Application.DTOs;

namespace EduLens.Application.Interfaces;

public interface INotificationService
{
    Task<NotificationDto?> GetByIdAsync(int id);

    Task<IEnumerable<NotificationDto>> GetAllAsync();

    Task<NotificationDto> CreateAsync(CreateNotificationDto notificationDto);

    Task<bool> UpdateAsync(int id, UpdateNotificationDto notificationDto);

    Task<bool> DeleteAsync(int id);
}
