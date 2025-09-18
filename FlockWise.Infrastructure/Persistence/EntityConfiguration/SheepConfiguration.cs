namespace FlockWise.Infrastructure.Persistence.EntityConfiguration;

public class SheepConfiguration : IEntityTypeConfiguration<Sheep>
{
    public void Configure(EntityTypeBuilder<Sheep> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnType("uuid")
            .ValueGeneratedNever();
        
        // User relationship
        builder.HasOne(e => e.User)
            .WithMany(u => u.Sheep)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
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
        
        builder.HasIndex(e => e.UserId);
        builder.HasIndex(e => e.FlockId);

    }
}