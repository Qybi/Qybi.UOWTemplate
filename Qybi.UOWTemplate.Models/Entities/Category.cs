
namespace Qybi.UOWTemplate.Models.Entities;

public record Category : IEntity
{
    public string Name { get; init; }
    public string? Description { get; init; }

    public virtual ICollection<Product> Products { get; init; }
}
