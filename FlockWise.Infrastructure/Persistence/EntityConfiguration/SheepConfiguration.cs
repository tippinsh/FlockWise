namespace FlockWise.Infrastructure.Persistence.EntityConfiguration;

public class SheepConfiguration : IEntityTypeConfiguration<Sheep>
{
    public void Configure(EntityTypeBuilder<Sheep> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnType("uuid")
            .ValueGeneratedNever();
        
        // Farm relationship
        builder.HasOne<Farm>()
            .WithMany()
            .HasForeignKey(e => e.FarmId)
            .OnDelete(DeleteBehavior.Cascade);

        // UpdatedByUser relationship
        builder.HasOne<User>()
            .WithMany()
            .HasForeignKey(e => e.UpdatedByUserId)
            .OnDelete(DeleteBehavior.SetNull);

        // Flock relationship
        builder.HasOne(s => s.Flock)
            .WithMany(f => f.Sheep)
            .HasForeignKey(s => s.FlockId)
            .OnDelete(DeleteBehavior.Cascade);

        // Weights relationship
        builder.HasMany(s => s.Weights)
            .WithOne()
            .HasForeignKey(w => w.SheepId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.FarmId);
        builder.HasIndex(e => e.FlockId);
        builder.HasIndex(e => e.UpdatedByUserId);
    }
}