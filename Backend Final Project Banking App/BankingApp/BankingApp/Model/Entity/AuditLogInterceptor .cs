using BankingApp.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

public class AuditLogInterceptor : SaveChangesInterceptor
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public AuditLogInterceptor(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
    {
        var context = eventData.Context;
        var userId = _httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "Anonymous";

        if (context == null) return base.SavingChanges(eventData, result);

        var logs = new List<AuditLog>();

        foreach (var entry in context.ChangeTracker.Entries())
        {
            if (entry.State == EntityState.Added || entry.State == EntityState.Modified || entry.State == EntityState.Deleted)
            {
                logs.Add(new AuditLog
                {
                    UserId = userId,
                    Description = $"{entry.Entity.GetType().Name} was {entry.State}",
                    Time = DateTime.UtcNow
                });
            }
        }

        if (logs.Any())
        {
            context.Set<AuditLog>().AddRange(logs);
        }

        return base.SavingChanges(eventData, result);
    }
}
