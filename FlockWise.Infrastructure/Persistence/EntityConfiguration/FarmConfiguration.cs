namespace FlockWise.Infrastructure.Persistence.EntityConfiguration;

public class FarmConfiguration : IEntityTypeConfiguration<Farm>
{
    public void Configure(EntityTypeBuilder<Farm> builder)
    {
        builder.ToTable("Farms");
        
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).ValueGeneratedOnAdd();

        builder.Property(e => e.Name)
            .HasMaxLength(100)
            .IsRequired();
        
        builder.Property(e => e.FlockMark)
            .HasMaxLength(100);
        
        builder.HasMany(f => f.Users)
            .WithOne(f => f.Farm)
            .HasForeignKey(f => f.FarmId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasMany(f => f.Fields)
            .WithOne(f => f.Farm)
            .HasForeignKey(f => f.FarmId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasMany(f => f.Flocks)
            .WithOne(f => f.Farm)
            .HasForeignKey(f => f.FarmId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}