namespace FlockWise.Infrastructure.Persistence.EntityConfiguration;

public class FlockNoteConfiguration : IEntityTypeConfiguration<FlockNote>
{
    public void Configure(EntityTypeBuilder<FlockNote> builder)
    {
        builder.ToTable("FlockNotes");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(e => e.Id)
            .HasColumnType("uuid")
            .ValueGeneratedNever();
        
        builder.Property(x => x.Note)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasOne(x => x.Flock)
            .WithMany(x => x.Notes)
            .HasForeignKey(x => x.FlockId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.FlockId);
        builder.HasIndex(x => x.UserId);
    }
}