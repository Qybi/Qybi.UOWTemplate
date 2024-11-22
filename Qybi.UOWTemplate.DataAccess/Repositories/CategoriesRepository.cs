using Microsoft.EntityFrameworkCore;
using Qybi.UOWTemplate.DataAccess.Abstractions.Repositories;
using Qybi.UOWTemplate.DataAccess.Contexts;
using Qybi.UOWTemplate.Models.Entities;

namespace Qybi.UOWTemplate.DataAccess.Repositories;

public class CategoriesRepository : Repository<Category>, ICategoriesRepository
{
    private readonly ApplicationDbContext _context;
    public CategoriesRepository(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllWithProducts()
    {
        return await _context.Category.Include(c => c.Products).ToListAsync();
    }
}
