using FlockWise.Core.Entities;

namespace FlockWise.Infrastructure.Persistence.EntityConfiguration;

public class LambingConfiguration : IEntityTypeConfiguration<Lambing>
{
    public void Configure(EntityTypeBuilder<Lambing> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnType("uuid")
            .ValueGeneratedNever();
        
        builder.Property(e => e.EweId)
            .HasColumnType("uuid")
            .IsRequired();
        
        builder.Property(e => e.TupId)
            .HasColumnType("uuid")
            .IsRequired();
        
        builder.HasIndex(e => e.EweId);
        builder.HasIndex(e => e.TupId);
        builder.HasIndex(e => e.LambingDate);
        
        builder.HasOne<Sheep>()
            .WithMany()
            .HasForeignKey(e => e.EweId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Lambing_Sheep_Ewe");

        builder.HasOne<Sheep>()
            .WithMany()
            .HasForeignKey(e => e.TupId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Lambing_Sheep_Tup");
        
        builder.HasMany(l => l.Notes)
            .WithOne(n => n.Lambing)
            .HasForeignKey(n => n.LambingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}