using EduLens.Application.Interfaces;
using EduLens.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EduLens.Infrastructure.Data.Repositories;

public class AuditLogRepository : IAuditLogRepository
{
    private readonly EduLensDbContext _context;

    public AuditLogRepository(EduLensDbContext context)
    {
        _context = context;
    }

    // GET BY ID
    public async Task<AuditLog?> GetByIdAsync(int id)
    {
        return await _context.AuditLogs
            .Include(a => a.User)
            .FirstOrDefaultAsync(a => a.AuditLogId == id);
    }

    // GET ALL
    public async Task<IEnumerable<AuditLog>> GetAllAsync()
    {
        return await _context.AuditLogs
            .Include(a => a.User)
            .ToListAsync();
    }

    // CREATE
    public async Task<AuditLog> CreateAsync(AuditLog auditLog)
    {
        await _context.AuditLogs.AddAsync(auditLog);

        await _context.SaveChangesAsync();

        return await GetByIdAsync(auditLog.AuditLogId) ?? auditLog;
    }

    // UPDATE
    public async Task UpdateAsync(AuditLog auditLog)
    {
        var existingAuditLog = await _context.AuditLogs
            .FirstOrDefaultAsync(a => a.AuditLogId == auditLog.AuditLogId);

        if (existingAuditLog == null)
            throw new KeyNotFoundException("Audit log not found.");

        existingAuditLog.Action = auditLog.Action;
        existingAuditLog.EntityName = auditLog.EntityName;
        existingAuditLog.EntityId = auditLog.EntityId;
        existingAuditLog.IpAddress = auditLog.IpAddress;

        await _context.SaveChangesAsync();
    }

    // DELETE
    public async Task DeleteAsync(AuditLog auditLog)
    {
        _context.AuditLogs.Remove(auditLog);

        await _context.SaveChangesAsync();
    }
}