using Qybi.UOWTemplate.Models.Entities;

namespace Qybi.UOWTemplate.DataAccess.Abstractions.Repositories;

public interface ICategoriesRepository : IRepository<Category>
{
    Task<IEnumerable<Category>> GetAllWithProducts();
}
