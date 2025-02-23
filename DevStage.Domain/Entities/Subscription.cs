using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DevStage.Domain.Entities;

[Index(nameof(Email), IsUnique = true)]
public class Subscription : EntityBase
{
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(50)]
    public string Email { get; set; } = string.Empty;
}