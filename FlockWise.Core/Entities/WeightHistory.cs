namespace FlockWise.Core.Entities;

public class WeightHistory
{
    public Guid Id { get; set; } = SequentialGuidGenerator.NewSequentialGuid();
    public Guid SheepId { get; set; }

    [Required]
    public int UserId { get; set; }

    [Microsoft.EntityFrameworkCore.Precision(9, 2)]
    public decimal ValueKg { get; set; }
    public DateTime WeighedAtUtc { get; set; }

    // Navigation properties
    public Sheep Sheep { get; set; } = null!;
    public User User { get; set; } = null!;
}