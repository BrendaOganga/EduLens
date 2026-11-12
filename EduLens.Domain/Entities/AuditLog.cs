namespace EduLens.Domain.Entities;

public class AuditLog
{
    public int AuditLogId { get; set; }

    public int UserId { get; set; }

    public string Action { get; set; } = string.Empty;

    public string EntityName { get; set; } = string.Empty;

    public int? EntityId { get; set; }

    public DateTime Timestamp { get; set; }

    public string? IpAddress { get; set; }

    // Navigation property
    public User User { get; set; } = null!;
}