using DevStage.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DevStage.Infrastructure;

public class DevStageDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Subscription> Subscriptions { get; set; }
}