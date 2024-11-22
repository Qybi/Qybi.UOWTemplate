using Qybi.UOWTemplate.Models.DTO;
using Qybi.UOWTemplate.Models.Entities;
using System.Reflection;

namespace Qybi.UOWTemplate.Helpers;

public static class ToDTOMapper
{
    public static ProductDTO Map(Product product)
    {
        return new ProductDTO
        {
            Code = product.Code,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CategoryId = product.CategoryId,
            Category = MapStrict(product.Category)
        };
    }

    public static ProductDTOStrict MapStrict(Product product)
    {
        return new ProductDTOStrict
        {
            Code = product.Code,
            Name = product.Name,
            Description = product.Description,
            Price = product.Price,
            CategoryId = product.CategoryId
        };
    }

    public static CategoryDTO Map(Category category)
    {
        return new CategoryDTO
        {
            Name = category.Name,
            Description = category.Description,
            Products = MapList(category.Products, MapStrict)
        };
    }

    public static CategoryDTOStrict MapStrict(Category category)
    {
        return new CategoryDTOStrict
        {
            Name = category.Name,
            Description = category.Description
        };
    }

    public static IEnumerable<TDTO> MapList<T, TDTO>(IEnumerable<T> entities, Func<T, TDTO> mapFunc)
    {
        return entities.Select(item => mapFunc(item)).ToList();
    }
}
