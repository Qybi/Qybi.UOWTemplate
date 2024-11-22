
using Qybi.UOWTemplate.DataAccess.Abstractions.Repositories;

namespace Qybi.UOWTemplate.DataAccess.Abstractions;

public interface IUnitOfWork
{
    IProductsRepository Products { get; }
    ICategoriesRepository Categories { get; }
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}
