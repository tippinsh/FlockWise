using FlockWise.Application.Models.Field;

namespace FlockWise.Application.Models.Flock;

public class FlockDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Location? Location { get; set; }
    public DateTimeOffset EstablishedDateUtc { get; set; }
    public Breed? Breed { get; set; }
    
    public ICollection<SheepDto>? Sheep { get; set; }
    public FieldDto? Field { get; set; }
    public ICollection<FlockNotesDto>? Notes { get; set; }
}