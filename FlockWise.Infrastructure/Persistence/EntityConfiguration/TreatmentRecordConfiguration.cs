namespace FlockWise.Infrastructure.Persistence.EntityConfiguration;

public class TreatmentRecordConfiguration : IEntityTypeConfiguration<TreatmentRecord>
{
    public void Configure(EntityTypeBuilder<TreatmentRecord> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnType("uuid")
            .ValueGeneratedNever();
        
        builder.Property(e => e.SheepId)
            .HasColumnType("uuid")
            .IsRequired();
        
        builder.Property(e => e.Complaint)
            .IsRequired()
            .HasMaxLength(500);
        
        builder.Property(e => e.Medication)
            .HasMaxLength(255);

        builder.Property(e => e.Dose)
            .HasMaxLength(100);

        builder.Property(e => e.Illness)
            .HasMaxLength(255);

        builder.Property(e => e.VetAdvice)
            .HasMaxLength(1000);
        
        builder.Property(e => e.DateOfTreatment)
            .IsRequired();

        builder.HasOne(e => e.Sheep)
            .WithMany()
            .HasForeignKey(e => e.SheepId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(e => e.User)
            .WithMany()
            .HasForeignKey(e => e.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.SheepId);
        builder.HasIndex(e => e.UserId);

        builder.ToTable("TreatmentRecords");
    }
}