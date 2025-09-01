namespace FlockWise.Infrastructure.Persistence.EntityConfiguration;

public class LambingNoteConfiguration : IEntityTypeConfiguration<LambingNote>
{
    public void Configure(EntityTypeBuilder<LambingNote> builder)
    {
        builder.ToTable("LambingNotes");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Note)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasIndex(x => x.LambingId);
        
        builder.HasOne(x => x.Lambing)
            .WithMany(x => x.Notes)
            .HasForeignKey(x => x.LambingId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}