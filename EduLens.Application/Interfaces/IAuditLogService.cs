using EduLens.Application.DTOs;

namespace EduLens.Application.Interfaces;

public interface IAuditLogService
{
    Task<AuditLogDto?> GetByIdAsync(int id);

    Task<IEnumerable<AuditLogDto>> GetAllAsync();

    Task<AuditLogDto> CreateAsync(CreateAuditLogDto auditLogDto);

    Task<bool> UpdateAsync(int id, UpdateAuditLogDto auditLogDto);

    Task<bool> DeleteAsync(int id);
}
