namespace FlockWise.Infrastructure.Persistence.EntityConfiguration;

public class BirthRecordConfiguration : IEntityTypeConfiguration<BirthRecord>
{
    public void Configure(EntityTypeBuilder<BirthRecord> builder)
    {
        builder.ToTable("BirthRecords");
        
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnType("uuid")
            .ValueGeneratedNever();

        builder.Property(e => e.SheepId)
            .IsRequired();

        builder.Property(e => e.DateOfBirthUtc)
            .IsRequired();

        builder.HasIndex(e => e.SheepId)
            .IsUnique();
    }
}