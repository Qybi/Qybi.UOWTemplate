
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
            CategoryId = product.Category.Id
        };
    }

    public static IEnumerable<Product> Map(IEnumerable<ProductDTO> products)
    {
        return products.Select(product => new Product
        {
            Code = product.Code,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CategoryId = product.Category.Id
        });
    }

    public static Category Map(CategoryDTO category)
    {
        return new Category
        {
            Name = category.Name,
            Description = category.Description
        };
    }

    public static IEnumerable<Category> Map(IEnumerable<CategoryDTO> categories)
    {
        return categories.Select(category => new Category
        {
            Name = category.Name,
            Description = category.Description
        });
    }
}
