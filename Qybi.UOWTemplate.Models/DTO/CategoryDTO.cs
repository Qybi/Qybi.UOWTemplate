﻿
using Qybi.UOWTemplate.Models.Entities;

namespace Qybi.UOWTemplate.Models.DTO;

public class CategoryDTO : CategoryDTOStrict
{
    public ICollection<Product>? Products { get; set; }

    public CategoryDTOStrict ToStrict()
    {
        return new CategoryDTOStrict
        {
            Name = Name,
            Description = Description
        };
    }
}
