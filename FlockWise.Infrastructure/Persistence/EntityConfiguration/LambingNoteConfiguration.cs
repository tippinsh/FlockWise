namespace FlockWise.Infrastructure.Persistence.EntityConfiguration;

public class LambingNoteConfiguration : IEntityTypeConfiguration<LambingNote>
{
    public void Configure(EntityTypeBuilder<LambingNote> builder)
    {
        builder.ToTable("LambingNotes");
        
        builder.HasKey(x => x.Id);
        
        builder.Property(e => e.Id)
            .HasColumnType("uuid")
            .ValueGeneratedNever();
        
        builder.Property(x => x.Note)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasOne(x => x.Lambing)
            .WithMany(x => x.Notes)
            .HasForeignKey(x => x.LambingId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(x => x.LambingId);
        builder.HasIndex(x => x.UserId);
    }
}