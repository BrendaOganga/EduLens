
using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduLens.Infrastructure.Data.Repositories;

public class NotificationRepository : INotificationRepository
{
    private readonly EduLensDbContext _context;

    public NotificationRepository(EduLensDbContext context)
    {
        _context = context;
    }

    public async Task<Notification?> GetByIdAsync(int id)
    {
        return await _context.Notifications
            .Include(n => n.User)
            .FirstOrDefaultAsync(n => n.NotificationId == id);
    }

    public async Task<IEnumerable<Notification>> GetAllAsync()
    {
        return await _context.Notifications
            .Include(n => n.User)
            .ToListAsync();
    }

    public async Task<Notification> CreateAsync(Notification notification)
    {
        await _context.Notifications.AddAsync(notification);
        await _context.SaveChangesAsync();

        return await GetByIdAsync(notification.NotificationId) ?? notification;
    }

    public async Task UpdateAsync(Notification notification)
    {
        var existingNotification = await _context.Notifications
            .FirstOrDefaultAsync(n => n.NotificationId == notification.NotificationId);

        if (existingNotification == null)
            throw new KeyNotFoundException("Notification not found.");

        existingNotification.Title = notification.Title;
        existingNotification.Message = notification.Message;
        existingNotification.IsRead = notification.IsRead;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Notification notification)
    {
        _context.Notifications.Remove(notification);
        await _context.SaveChangesAsync();
    }
}
