
using Microsoft.EntityFrameworkCore;
using Qybi.UOWTemplate.DataAccess.Abstractions;
using Qybi.UOWTemplate.DataAccess.Contexts;
using Qybi.UOWTemplate.Models;
using System.Linq.Expressions;

namespace Qybi.UOWTemplate.DataAccess;

public class Repository<T> : IRepository<T> where T : IEntity
{
    private readonly ApplicationDbContext _dbContext;

    public Repository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T?> GetById(int id, CancellationToken cancellationToken = default)
    {
        return await _dbContext.Set<T>().FindAsync(id);
    }

    public IQueryable<T> GetQueryable(Expression<Func<T, bool>> expression,
        Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null)
    {
        var query = _dbContext.Set<T>().Where(expression);
        return orderBy != null ? orderBy(query) : query;
    }

    public Task<List<T>> GetListAsync(Expression<Func<T, bool>>? expression, Func<IQueryable<T>,
        IOrderedQueryable<T>>? orderBy = null, CancellationToken cancellationToken = default)
    {
        var query = expression != null ? _dbContext.Set<T>().Where(expression) : _dbContext.Set<T>();
        return orderBy != null
            ? orderBy(query).ToListAsync(cancellationToken)
            : query.ToListAsync(cancellationToken);
    }

    public Task<List<T>> GetAllAsync(CancellationToken cancellationToken)
    {
        return _dbContext.Set<T>().ToListAsync(cancellationToken);
    }

    public Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, string includeProperties, CancellationToken cancellationToken = default)
    {
        var query = _dbContext.Set<T>().AsQueryable();

        query = includeProperties.Split(new char[] { ',' },
            StringSplitOptions.RemoveEmptyEntries).Aggregate(query, (current, includeProperty)
            => current.Include(includeProperty));

        return query.SingleOrDefaultAsync(expression);
    }

    public T Add(T entity)
    {
        return _dbContext.Set<T>().Add(entity).Entity;
    }

    public void Update(T entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
    }

    public void UpdateRange(IEnumerable<T> entities)
    {
        _dbContext.Set<T>().UpdateRange(entities);
    }

    public void Delete(T entity)
    {
        _dbContext.Set<T>().Remove(entity);
    }
}
