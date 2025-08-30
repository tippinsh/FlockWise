using FlockWise.Core.Events.Sheep;

namespace FlockWise.Infrastructure.Persistence;

public class FlockWiseDbContext(DbContextOptions<FlockWiseDbContext> options) : DbContext(options)
{
    public DbSet<Flock> Flocks { get; set; }

    public DbSet<Sheep> Sheep { get; set; }

    public DbSet<TreatmentRecord> TreatmentRecords { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new FlockConfiguration());
    }
}