using FlockWise.Infrastructure.Persistence.EntityConfiguration;

namespace FlockWise.Infrastructure.Persistence;

public class FlockWiseDbContext(DbContextOptions<FlockWiseDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }
    public DbSet<Flock> Flocks { get; set; }
    public DbSet<Sheep> Sheep { get; set; }
    public DbSet<TreatmentRecord> TreatmentRecords { get; set; }
    public DbSet<BirthRecord> BirthRecords { get; set; }
    public DbSet<Field> Fields { get; set; }
    public DbSet<FlockNote> FlockNotes { get; set; }
    public DbSet<LambingRecord> LambingRecords { get; set; }
    public DbSet<LambingNote> LambingNotes { get; set; }
    public DbSet<WeightHistory> WeightHistories { get; set; }
    public DbSet<Farm> Farms { get; set; }
    
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<Enum>()
            .HaveConversion<string>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new FlockConfiguration());
        modelBuilder.ApplyConfiguration(new SheepConfiguration());
        modelBuilder.ApplyConfiguration(new FieldConfiguration());
        modelBuilder.ApplyConfiguration(new LambingConfiguration());
        modelBuilder.ApplyConfiguration(new FlockNoteConfiguration());
        modelBuilder.ApplyConfiguration(new BirthRecordConfiguration());
        modelBuilder.ApplyConfiguration(new LambingNoteConfiguration());
        modelBuilder.ApplyConfiguration(new WeightHistoryConfiguration());
        modelBuilder.ApplyConfiguration(new TreatmentRecordConfiguration());
        modelBuilder.ApplyConfiguration(new FarmConfiguration());
    }
}