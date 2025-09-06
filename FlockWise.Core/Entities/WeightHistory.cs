namespace FlockWise.Core.Entities;

public class WeightHistory
{
    public Guid Id { get; set; } = SequentialGuidGenerator.NewSequentialGuid();
    
    public Guid SheepId { get; set; }
    
    [Microsoft.EntityFrameworkCore.Precision(9, 2)]
    public decimal ValueKg { get; set; }

    public DateTime WeighedAtUtc { get; set; }
}