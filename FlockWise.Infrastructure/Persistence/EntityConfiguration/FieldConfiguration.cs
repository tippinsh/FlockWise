namespace FlockWise.Infrastructure.Persistence.EntityConfiguration;

public class FieldConfiguration : IEntityTypeConfiguration<Field>
{
    public void Configure(EntityTypeBuilder<Field> builder)
    {
        builder.ToTable("Fields");
        
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnType("uuid")
            .ValueGeneratedNever();

        // User relationship
        builder.HasOne(e => e.User)
            .WithMany(u => u.Fields)
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(e => e.Size)
            .IsRequired();

        builder.Property(e => e.Alias)
            .HasMaxLength(100);

        builder.Property(e => e.Latitude)
            .HasPrecision(10, 7);

        builder.Property(e => e.Longitude)
            .HasPrecision(10, 7);

        builder.HasIndex(e => e.UserId);
    }
}