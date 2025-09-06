namespace FlockWise.Infrastructure.Persistence.EntityConfiguration;

public class WeightHistoryConfiguration : IEntityTypeConfiguration<WeightHistory>
{
    public void Configure(EntityTypeBuilder<WeightHistory> builder)
    {
        builder.ToTable("WeightHistory");
        
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnType("uuid")
            .ValueGeneratedNever();
        
        builder.Property(e => e.SheepId)
            .IsRequired();

        builder.Property(e => e.ValueKg)
            .HasPrecision(9, 2)
            .IsRequired();

        builder.Property(e => e.WeighedAtUtc)
            .IsRequired();

        builder.HasIndex(e => new { e.SheepId, e.WeighedAtUtc });
    }
}