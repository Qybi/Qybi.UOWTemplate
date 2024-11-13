
using System.ComponentModel.DataAnnotations;

namespace Qybi.UOWTemplate.Models.Entities;

public record Product : IEntity
{
    [Required]
    [MaxLength(50)]
    public string Code { get; init; } = new Guid().ToString();
    public string Name { get; init; } = string.Empty;
    public string? Description { get; init; }
    [Required]
    public decimal Price { get; init; }
    public int CategoryId { get; init; }

    public virtual Category Category { get; init; } = null!;
}
