
using Qybi.UOWTemplate.Models.DTO;
using Qybi.UOWTemplate.Models.Entities;

namespace Qybi.UOWTemplate.Helpers;

public static class ToEntityMapper
{
    public static Product Map(ProductDTOStrict productDTO)
    {
        return new Product
        {
            Code = productDTO.Code,
            Name = productDTO.Name,
            Description = productDTO.Description,
            Price = productDTO.Price,
            CategoryId = productDTO.CategoryId
        };
    }

    public static Category Map(CategoryDTOStrict categoryDTO)
    {
        return new Category
        {
            Name = categoryDTO.Name,
            Description = categoryDTO.Description
        };
    }

    public static IEnumerable<TEntity> MapList<T, TEntity>(IEnumerable<T> dtos, Func<T, TEntity> mapFunc)
    {
        return dtos.Select(dto => mapFunc(dto));
    }
}
