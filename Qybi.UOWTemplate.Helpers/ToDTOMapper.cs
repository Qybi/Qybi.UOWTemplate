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
    public static IEnumerable<ProductDTO> Map(IEnumerable<Product> products)
    {
        return products.Select(item => new ProductDTO
        {
            Code = item.Code,
            Name = item.Name,
            Description = item.Description,
            Price = item.Price,
            Category = item.Category
        }).ToList();
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

    public static IEnumerable<CategoryDTO> Map(IEnumerable<Category> categories)
    {
        return categories.Select(item => new CategoryDTO
        {
            Name = item.Name,
            Description = item.Description,
            Products = item.Products
        }).ToList();
    }
}
