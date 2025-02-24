using Bogus;
using DevStage.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DevStage.Infrastructure;

    public static class MigrationSeeder
    {
        public static async Task MigrateDatabaseAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var scopedServices = scope.ServiceProvider;

            try
            {
                var dbContext = scopedServices.GetRequiredService<DevStageDbContext>();
                var pendingMigrations = (await dbContext.Database.GetPendingMigrationsAsync()).ToList();

                if (!pendingMigrations.Any())
                {
                    Console.WriteLine(@"No pending migrations were found. The database is up-to-date.");
                    return;
                }

                Console.WriteLine(@"The following migrations will be applied:");
                foreach (var migration in pendingMigrations)
                {
                    Console.WriteLine($@"- {migration}");
                }

                await dbContext.Database.MigrateAsync();
                Console.WriteLine(@"Migrations applied successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($@"An error occurred during database migration: {ex.Message}");
                throw;
            }
        }
        public static async Task SeedDatabaseAsync(this IServiceProvider serviceProvider, int seedCount = 1000, bool force = false)
        {
            using var scope = serviceProvider.CreateScope();
            var dbContext = scope.ServiceProvider.GetRequiredService<DevStageDbContext>();

            if (!await dbContext.Subscriptions.AnyAsync() || force)
            {
                var subscriptions = new List<Subscription>();

                var subscriptionFaker = new Faker<Subscription>()
                    .RuleFor(s => s.Name, f => f.Name.FullName())
                    .RuleFor(s => s.Email, (f, s) =>
                    {
                        var names = s.Name.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                        var firstName = names.First();
                        var lastName = names.Length > 1 ? names.Last() : string.Empty;
                        return f.Internet.Email(firstName.ToLower(), lastName.ToLower());
                    })
                    .RuleFor(s => s.ReferredId, f => null);


                for (int i = 0; i < seedCount; i++)
                {
                    subscriptions.Add(subscriptionFaker.Generate());
                }

                await dbContext.Subscriptions.AddRangeAsync(subscriptions);
                await dbContext.SaveChangesAsync();

                var random = new Random();
                foreach (var subscription in subscriptions)
                {
                    if (random.NextDouble() < 0.5)
                    {
                        var possibleReferrers = subscriptions.Where(s => s.Id != subscription.Id).ToList();
                        if (possibleReferrers.Any())
                        {
                            var referrer = possibleReferrers[random.Next(possibleReferrers.Count)];
                            subscription.ReferredId = referrer.Id;
                        }
                    }
                }

                await dbContext.SaveChangesAsync();

                var invites = new List<Invite>();
                foreach (var subscription in subscriptions)
                {
                    if (subscription.ReferredId.HasValue)
                    {
                        invites.Add(new Invite
                        {
                            SubscriberId = subscription.ReferredId.Value
                        });
                    }
                }

                await dbContext.Invites.AddRangeAsync(invites);
                await dbContext.SaveChangesAsync();
            }
        }
    }