using FlockWise.Core.Entities;

namespace FlockWise.Infrastructure.Persistence.EntityConfiguration;

public class FlockConfiguration : IEntityTypeConfiguration<Flock>
{
    public void Configure(EntityTypeBuilder<Flock> builder)
    {
        builder.ToTable("Flocks");

        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnType("uuid")
            .ValueGeneratedNever();
        
        builder.HasMany(f => f.Sheep)
            .WithOne(s => s.Flock)
            .HasForeignKey(s => s.FlockId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(e => e.Name)
            .HasMaxLength(100);

        builder.Property(e => e.EstablishedDate)
            .IsRequired();
    }
}