using Microsoft.EntityFrameworkCore;
using Zebra.Api.Persistence.Entities;

namespace Zebra.Api.Persistence;

public class ZebraContext : DbContext
{
    public ZebraContext(DbContextOptions<ZebraContext> options) : base(options)
    {

    }

    public DbSet<Animal> Animals { get; set; } = default!;
    public DbSet<Category> Categories { get; set; } = default!;
    public DbSet<Habitat> Habitats { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var foreignKeys = modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys());

        foreach(var foreignKey in foreignKeys)
            foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            
        base.OnModelCreating(modelBuilder);
    }
}