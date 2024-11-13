using Qybi.UOWTemplate.Models.DTO;
using Qybi.UOWTemplate.Models.Entities;

namespace Qybi.UOWTemplate.Helpers;

public class ToDTOMapper
{
    public static ProductDTO Map(Product product)
    {
        return new ProductDTO
        {
            Code = product.Code,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Category = product.Category
        };
    }

    public static CategoryDTO Map(Category category)
    {
        return new CategoryDTO
        {
            Name = category.Name,
            Description = category.Description,
            Products = category.Products
        };
    }
}
