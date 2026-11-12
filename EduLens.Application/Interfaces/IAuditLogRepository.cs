using EduLens.Domain.Entities;

namespace EduLens.Application.Interfaces;

public interface IAuditLogRepository
{
    Task<AuditLog?> GetByIdAsync(int id);

    Task<IEnumerable<AuditLog>> GetAllAsync();

    Task<AuditLog> CreateAsync(AuditLog auditLog);

    Task UpdateAsync(AuditLog auditLog);

    Task DeleteAsync(AuditLog auditLog);
}