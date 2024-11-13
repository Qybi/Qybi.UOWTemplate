
using System.ComponentModel.DataAnnotations;

namespace Qybi.UOWTemplate.Models;

public record IEntity
{
    [Key]
    public int Id { get; init; }
    [Required]
    public DateTime CreatedAt { get; init; } = DateTime.Now;
    public DateTime? UpdatedAt { get; init; }
}
