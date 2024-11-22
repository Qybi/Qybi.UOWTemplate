
using Qybi.UOWTemplate.Models.Entities;

namespace Qybi.UOWTemplate.Models.DTO;

public class CategoryDTO : CategoryDTOStrict
{
    public IEnumerable<ProductDTOStrict>? Products { get; set; }

    public CategoryDTOStrict ToStrict()
    {
        return new CategoryDTOStrict
        {
            Name = Name,
            Description = Description
        };
    }
}
