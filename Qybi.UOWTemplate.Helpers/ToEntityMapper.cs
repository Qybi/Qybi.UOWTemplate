
using Qybi.UOWTemplate.Models.DTO;
using Qybi.UOWTemplate.Models.Entities;

namespace Qybi.UOWTemplate.Helpers;

public static class ToEntityMapper
{
    public static Product Map(this ProductDTO productDTO)
    {
        return new Product
        {
            Code = productDTO.Code,
            Name = productDTO.Name,
            Description = productDTO.Description,
            Price = productDTO.Price,
            CategoryId = productDTO.Category.Id
        };
    }

    public static Category Map(this CategoryDTO categoryDTO)
    {
        return new Category
        {
            Name = categoryDTO.Name,
            Description = categoryDTO.Description
        };
    }

    public static IEnumerable<TEntity> MapList<T, TEntity>(this IEnumerable<T> dtos, Func<T, TEntity> mapFunc)
    {
        return dtos.Select(dto => mapFunc(dto));
    }
}
