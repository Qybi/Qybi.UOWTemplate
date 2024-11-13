
using Qybi.UOWTemplate.Models.DTO;
using Qybi.UOWTemplate.Models.Entities;

namespace Qybi.UOWTemplate.Helpers;

public class ToEntityMapper
{
    public static Product Map(ProductDTO product)
    {
        return new Product
        {
            Code = product.Code,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            Category = product.Category
        };
    }

    public static Category Map(CategoryDTO category)
    {
        return new Category
        {
            Name = category.Name,
            Description = category.Description,
            Products = category.Products
        };
    }
}
