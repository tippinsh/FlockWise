namespace FlockWise.Application.Models.Flock;

public class FlockWithSheepDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Location? Location { get; set; }
    public DateTimeOffset EstablishedDateUtc { get; set; }
    public Breed? Breed { get; set; }
    public ICollection<SheepDto> Sheep { get; set; } = new List<SheepDto>();
}