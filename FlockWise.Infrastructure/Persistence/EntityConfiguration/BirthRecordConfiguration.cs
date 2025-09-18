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
        
        builder.HasOne(br => br.Sheep)
            .WithOne(s => s.BirthRecord)
            .HasForeignKey<BirthRecord>(br => br.SheepId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasOne(br => br.Father)
            .WithMany()
            .HasForeignKey(br => br.FatherId)
            .OnDelete(DeleteBehavior.Restrict);
        
        builder.HasOne(br => br.Mother)
            .WithMany()
            .HasForeignKey(br => br.MotherId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasIndex(e => e.SheepId)
            .IsUnique();
    }
}