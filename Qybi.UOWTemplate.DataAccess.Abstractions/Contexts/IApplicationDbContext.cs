
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Qybi.UOWTemplate.DataAccess.Abstractions.Contexts;

public interface IApplicationDbContext
{
    EntityEntry Entry(object entity);
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
