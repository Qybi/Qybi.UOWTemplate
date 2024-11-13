
using System.ComponentModel.DataAnnotations;

namespace Qybi.UOWTemplate.Models;

public interface IEntity
{
    [Key]
    public int Id { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}
