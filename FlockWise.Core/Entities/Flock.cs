namespace FlockWise.Core.Entities;

public class Flock
{
    public Guid Id { get; init; } = SequentialGuidGenerator.NewSequentialGuid();
    public string? Name { get; set; }
    
    [StringLength(100)]
    public string? Location { get; set; }
    public DateTimeOffset EstablishedDate { get; init; }
    
    [StringLength(100)]
    public string? Breed { get; set; }
    
    public List<string>? Notes { get; set; }
    
    // Navigation properties
    public ICollection<Sheep> Sheep { get; set; } = [];
}