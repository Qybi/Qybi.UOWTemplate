﻿using Qybi.UOWTemplate.Models;
using System.Linq.Expressions;

namespace Qybi.UOWTemplate.DataAccess.Abstractions;

public interface IRepository<T> where T : IEntity
{
    Task<T?> GetById(int id, CancellationToken cancellationToken = default);
    IQueryable<T> GetQueryable(Expression<Func<T, bool>> expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null);
    Task<List<T>> GetListAsync(Expression<Func<T, bool>>? expression, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, CancellationToken cancellationToken = default);
    Task<List<T>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<T?> SingleOrDefaultAsync(Expression<Func<T, bool>> expression, string includeProperties, CancellationToken cancellationToken = default);
    T Add(T entity);
    void Update(T entity);
    void UpdateRange(IEnumerable<T> entities);
    void Delete(T entity);
}
