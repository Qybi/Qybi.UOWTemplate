
using Qybi.UOWTemplate.Models.Entities;

namespace Qybi.UOWTemplate.Models.DTO;

public class ProductDTO : ProductDTOStrict
{
    public CategoryDTOStrict? Category { get; init; } = null!;

    public ProductDTOStrict ToStrict()
    {
        return new ProductDTOStrict
        {
            Code = Code,
            Name = Name,
            Description = Description,
            Price = Price,
            CategoryId = CategoryId
        };
    }
}
