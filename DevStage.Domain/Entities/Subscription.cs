using System.ComponentModel.DataAnnotations;

namespace DevStage.Domain.Entities;

public class Subscription : EntityBase
{
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string Email { get; set; } = string.Empty;
}