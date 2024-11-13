using Microsoft.EntityFrameworkCore;
using Qybi.UOWTemplate.DataAccess.Abstractions.Contexts;
using Qybi.UOWTemplate.Models;
using Qybi.UOWTemplate.Models.Entities;

namespace Qybi.UOWTemplate.DataAccess.Contexts;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
    {
        // cycling all entities flagged for creation/update and automatically setting updatedAt timestamp
        foreach (var item in ChangeTracker.Entries<IEntity>().AsEnumerable())
            item.Entity.UpdatedAt = DateTime.Now;

        return base.SaveChangesAsync(cancellationToken);
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // For any other DB engine than SQLServer, you need to map the entity properties to the correct data types
        // Relationship reference: https://docs.microsoft.com/en-us/ef/core/modeling/relationships
        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.CategoryId);
    }
}
