
using EduLens.Domain.Entities;

namespace EduLens.Application.Interfaces;

public interface INotificationRepository
{
    Task<Notification?> GetByIdAsync(int id);

    Task<IEnumerable<Notification>> GetAllAsync();

    Task<Notification> CreateAsync(Notification notification);

    Task UpdateAsync(Notification notification);

    Task DeleteAsync(Notification notification);
}
