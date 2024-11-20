using System;
namespace Qybi.UOWTemplate.Models.DTO;

public class ProductDTOStrict
{
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
    public decimal Price { get; init; }
    public int CategoryId { get; set; }
}
