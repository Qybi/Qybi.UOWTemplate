using Microsoft.EntityFrameworkCore;
using Qybi.UOWTemplate.DataAccess.Abstractions.Contexts;
using Qybi.UOWTemplate.DataAccess.Abstractions.Repositories;
using Qybi.UOWTemplate.DataAccess.Contexts;
using Qybi.UOWTemplate.Models.Entities;

namespace Qybi.UOWTemplate.DataAccess.Repositories;

public class ProductsRepository : Repository<Product>, IProductsRepository
{
    private readonly ApplicationDbContext _context;
    public ProductsRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Product>> GetAllWithCategory()
    {
        return await _context.Product.Include(p => p.Category).ToListAsync();
    }
}
