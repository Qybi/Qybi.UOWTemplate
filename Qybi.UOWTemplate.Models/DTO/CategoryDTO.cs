
using Qybi.UOWTemplate.Models.Entities;

namespace Qybi.UOWTemplate.Models.DTO;

public class CategoryDTO
{
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
    public ICollection<Product>? Products { get; set; }
}
