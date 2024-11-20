
using Qybi.UOWTemplate.Models.Entities;

namespace Qybi.UOWTemplate.Models.DTO;

public class ProductDTO : ProductDTOStrict
{
    public Category Category { get; init; } = null!;
}
