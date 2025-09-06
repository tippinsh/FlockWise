namespace FlockWise.Infrastructure.Persistence.EntityConfiguration;

public class SheepConfiguration : IEntityTypeConfiguration<Sheep>
{
    public void Configure(EntityTypeBuilder<Sheep> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnType("uuid")
            .ValueGeneratedNever();
        
        builder.HasOne(s => s.Flock)
            .WithMany(f => f.Sheep)
            .HasForeignKey(s => s.FlockId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(s => s.Weights)
            .WithOne()
            .HasForeignKey(w => w.SheepId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(s => s.BirthRecord)
            .WithOne()
            .HasForeignKey<BirthRecord>(s => s.SheepId)
            .OnDelete(DeleteBehavior.SetNull);
    }
}