namespace FlockWise.Core.Entities;

public class Field
{
    public Guid Id { get; set; } = SequentialGuidGenerator.NewSequentialGuid();
    
    [Required]
    public int FarmId { get; set; }

    public double Size { get; set; }

    [StringLength(100)]
    public string? Alias { get; set; }

    [Range(-90, 90)]
    public decimal? Latitude { get; set; }

    [Range(-180, 180)]
    public decimal? Longitude { get; set; }
    
    // Navigation properties
    public Farm Farm { get; set; }
}