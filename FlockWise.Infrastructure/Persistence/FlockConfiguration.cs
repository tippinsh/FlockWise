namespace FlockWise.Infrastructure.Persistence;

public class FlockConfiguration : IEntityTypeConfiguration<Flock>
{
    public void Configure(EntityTypeBuilder<Flock> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnType("uuid")
            .ValueGeneratedNever();

        builder.Property(e => e.Name)
            .HasMaxLength(100);

        builder.Property(e => e.EstablishedDate)
            .IsRequired();
    }
}