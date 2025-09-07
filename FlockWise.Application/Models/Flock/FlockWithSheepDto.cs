namespace FlockWise.Application.Models.Flock;

public class FlockWithSheepDto : FlockDto
{
    ICollection<SheepDto> Sheep { get; set; } = [];
}