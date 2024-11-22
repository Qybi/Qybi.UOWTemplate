
using Qybi.UOWTemplate.Models.Entities;

namespace Qybi.UOWTemplate.DataAccess.Abstractions.Repositories;

public interface IProductsRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetAllWithCategory();
}
