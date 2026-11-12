namespace EduLens.Application.DTOs;

public class AuditLogDto
{
    public int AuditLogId { get; set; }

    public int UserId { get; set; }

    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public string Action { get; set; } = string.Empty;

    public string EntityName { get; set; } = string.Empty;

    public int? EntityId { get; set; }

    public DateTime Timestamp { get; set; }

    public string? IpAddress { get; set; }
}

public class CreateAuditLogDto
{
    public int UserId { get; set; }

    public string Action { get; set; } = string.Empty;

    public string EntityName { get; set; } = string.Empty;

    public int? EntityId { get; set; }

    public string? IpAddress { get; set; }
}

public class UpdateAuditLogDto
{
    public string Action { get; set; } = string.Empty;

    public string EntityName { get; set; } = string.Empty;

    public int? EntityId { get; set; }

    public string? IpAddress { get; set; }
}