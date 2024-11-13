
using System.ComponentModel.DataAnnotations;

namespace Qybi.UOWTemplate.Models;

public record IEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; }
}
