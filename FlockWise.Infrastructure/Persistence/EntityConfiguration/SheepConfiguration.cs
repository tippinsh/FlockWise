using FlockWise.Core.Entities;

namespace FlockWise.Infrastructure.Persistence.EntityConfiguration;

public class SheepConfiguration : IEntityTypeConfiguration<Sheep>
{
    public void Configure(EntityTypeBuilder<Sheep> builder)
    {
        builder.HasKey(e => e.Id);
        
        builder.Property(e => e.Id)
            .HasColumnType("uuid")
            .ValueGeneratedNever();
        
        builder.HasOne(s => s.Flock)
            .WithMany(f => f.Sheep)
            .HasForeignKey(s => s.FlockId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}