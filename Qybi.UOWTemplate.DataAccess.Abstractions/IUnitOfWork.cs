
namespace Qybi.UOWTemplate.DataAccess.Abstractions;

public interface IUnitOfWork
{
    IRepository Repository();
    Task<int> CommitAsync(CancellationToken cancellationToken = default);
}
