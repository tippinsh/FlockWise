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

        builder.HasOne(e => e.Sheep)
            .WithMany(s => s.Weights)
            .HasForeignKey(e => e.SheepId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => new { e.SheepId, e.WeighedAtUtc });
        builder.HasIndex(e => e.UserId);
    }
}