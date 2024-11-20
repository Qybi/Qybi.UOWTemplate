using Qybi.UOWTemplate.Models;
using System.Linq.Expressions;

namespace Qybi.UOWTemplate.DataAccess.Abstractions;

public interface IRepository
{
    Task<T?> GetById<T>(int id, CancellationToken cancellationToken = default) where T : IEntity;
    IQueryable<T> GetQueryable<T>(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null) where T : IEntity;
    Task<List<T>> GetListAsync<T>(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, CancellationToken cancellationToken = default) where T : class;
    Task<List<T>> GetAllAsync<T>(CancellationToken cancellationToken = default) where T : IEntity;
    Task<T?> SingleOrDefaultAsync<T>(Expression<Func<T, bool>> expression, string includeProperties, CancellationToken cancellationToken = default) where T : IEntity;
    T Add<T>(T entity) where T : IEntity;
    void Update<T>(T entity) where T : IEntity;
    void UpdateRange<T>(IEnumerable<T> entities) where T : IEntity;
    void Delete<T>(T entity) where T : IEntity;
}
