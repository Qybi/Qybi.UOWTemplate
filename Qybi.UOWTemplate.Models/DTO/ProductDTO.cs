
using Qybi.UOWTemplate.Models.Entities;

namespace Qybi.UOWTemplate.Models.DTO;

public class ProductDTO
{
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
    public decimal Price { get; init; }
    public Category Category { get; init; } = null!;
}
