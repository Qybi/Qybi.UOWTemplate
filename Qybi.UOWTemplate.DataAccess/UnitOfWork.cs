using Qybi.UOWTemplate.DataAccess.Abstractions;
using Qybi.UOWTemplate.DataAccess.Contexts;

namespace Qybi.UOWTemplate.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private bool _disposed;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    public IRepository Repository()
    {
        return new Repository(_context);
    }
    public Task<int> CommitAsync(CancellationToken cancellationToken)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }

    // dispose stuff
    // disable finalizer
    ~UnitOfWork()
    {
        Dispose(false);
    }
    // manually dispose context if not already disposed
    public void Dispose() { 
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
            if (disposing)
                _context.Dispose();
        _disposed = true;
    }
}
