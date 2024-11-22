using Microsoft.Extensions.DependencyInjection;
using Qybi.UOWTemplate.DataAccess.Abstractions;
using Qybi.UOWTemplate.DataAccess.Abstractions.Repositories;
using Qybi.UOWTemplate.DataAccess.Contexts;

namespace Qybi.UOWTemplate.DataAccess;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly IServiceProvider _services;

    public UnitOfWork(ApplicationDbContext context, IServiceProvider services)
    {
        _context = context;
        _services = services;
    }

    private IProductsRepository? _productsRepository;
    private ICategoriesRepository? _categoriesRepository;
    public IProductsRepository Products
    {
        get
        {
            if (_productsRepository is null)
                _productsRepository = _services.GetRequiredService<IProductsRepository>();

            return _productsRepository;
        }
    }

    // short version of the above getter
    public ICategoriesRepository Categories => _categoriesRepository ??= _services.GetRequiredService<ICategoriesRepository>();

    public Task<int> CommitAsync(CancellationToken cancellationToken = default)
    {
        return _context.SaveChangesAsync(cancellationToken);
    }
}
