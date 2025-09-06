namespace FlockWise.Infrastructure.Persistence.EntityConfiguration;

public class FlockConfiguration : IEntityTypeConfiguration<Flock>
{
    public void Configure(EntityTypeBuilder<Flock> builder)
    {
        builder.ToTable("Flocks");

        builder.HasKey(e => e.Id);
        
        builder.HasOne(e => e.User)
            .WithMany(u => u.Flocks)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.Property(e => e.Id)
            .HasColumnType("uuid")
            .ValueGeneratedNever();
        
        builder.HasMany(f => f.Sheep)
            .WithOne(s => s.Flock)
            .HasForeignKey(s => s.FlockId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(e => e.Name)
            .HasMaxLength(100);

        builder.Property(e => e.EstablishedDateUtc)
            .IsRequired();
        
        builder.HasOne(e => e.Field)
            .WithMany()
            .HasForeignKey(e => e.FieldId)
            .OnDelete(DeleteBehavior.SetNull);
        
        builder.HasMany(f => f.Notes)
            .WithOne(f => f.Flock)
            .HasForeignKey(f => f.FlockId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(f => f.FieldId);
        builder.HasIndex(f => f.UserId);

    }
}