namespace FlockWise.Infrastructure.Persistence.EntityConfiguration;

public class LambingConfiguration : IEntityTypeConfiguration<LambingRecord>
{
    public void Configure(EntityTypeBuilder<LambingRecord> builder)
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
        
        builder.HasOne(e => e.User)
            .WithMany(u => u.LambingRecords)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
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
        
        builder.HasIndex(e => e.EweId);
        builder.HasIndex(e => e.TupId);
        builder.HasIndex(e => e.LambingDateUtc);
    }
}