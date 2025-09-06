namespace FlockWise.Infrastructure.Persistence.EntityConfiguration;

public class FlockNoteConfiguration : IEntityTypeConfiguration<FlockNote>
{
    public void Configure(EntityTypeBuilder<FlockNote> builder)
    {
        builder.ToTable("FlockNotes");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Note)
            .IsRequired()
            .HasMaxLength(255);
        
        builder.HasIndex(x => x.FlockId);
        
        builder.HasOne(x => x.Flock)
            .WithMany(x => x.Notes)
            .HasForeignKey(x => x.FlockId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}