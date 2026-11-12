using EduLens.Application.DTOs;
using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;

namespace EduLens.Application.Services;

public class AuditLogService : IAuditLogService
{
    private readonly IAuditLogRepository _auditLogRepository;

    public AuditLogService(IAuditLogRepository auditLogRepository)
    {
        _auditLogRepository = auditLogRepository;
    }

    // GET BY ID
    public async Task<AuditLogDto?> GetByIdAsync(int id)
    {
        var auditLog = await _auditLogRepository.GetByIdAsync(id);

        if (auditLog == null)
            return null;

        return MapToDto(auditLog);
    }

    // GET ALL
    public async Task<IEnumerable<AuditLogDto>> GetAllAsync()
    {
        var auditLogs = await _auditLogRepository.GetAllAsync();

        return auditLogs.Select(MapToDto);
    }

    // CREATE
    public async Task<AuditLogDto> CreateAsync(CreateAuditLogDto auditLogDto)
    {
        var auditLog = new AuditLog
        {
            UserId = auditLogDto.UserId,
            Action = auditLogDto.Action,
            EntityName = auditLogDto.EntityName,
            EntityId = auditLogDto.EntityId,
            IpAddress = auditLogDto.IpAddress,
            Timestamp = DateTime.UtcNow
        };

        var createdAuditLog = await _auditLogRepository.CreateAsync(auditLog);

        return MapToDto(createdAuditLog);
    }

    // UPDATE
    public async Task<bool> UpdateAsync(int id, UpdateAuditLogDto auditLogDto)
    {
        var auditLog = await _auditLogRepository.GetByIdAsync(id);

        if (auditLog == null)
            return false;

        auditLog.Action = auditLogDto.Action;
        auditLog.EntityName = auditLogDto.EntityName;
        auditLog.EntityId = auditLogDto.EntityId;
        auditLog.IpAddress = auditLogDto.IpAddress;

        await _auditLogRepository.UpdateAsync(auditLog);

        return true;
    }

    // DELETE
    public async Task<bool> DeleteAsync(int id)
    {
        var auditLog = await _auditLogRepository.GetByIdAsync(id);

        if (auditLog == null)
            return false;

        await _auditLogRepository.DeleteAsync(auditLog);

        return true;
    }

    // ENTITY TO DTO MAPPING
    private static AuditLogDto MapToDto(AuditLog auditLog)
    {
        return new AuditLogDto
        {
            AuditLogId = auditLog.AuditLogId,
            UserId = auditLog.UserId,
            FirstName = auditLog.User?.FirstName ?? string.Empty,
            LastName = auditLog.User?.LastName ?? string.Empty,
            Action = auditLog.Action,
            EntityName = auditLog.EntityName,
            EntityId = auditLog.EntityId,
            Timestamp = auditLog.Timestamp,
            IpAddress = auditLog.IpAddress
        };
    }
}