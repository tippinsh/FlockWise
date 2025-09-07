namespace FlockWise.Application.Models.Flock;

public class FlockWithSheepAndNotesDto : FlockDto
{
    ICollection<SheepDto> Sheep { get; set; } = [];
    ICollection<FlockNotesDto>? Notes { get; set; } = [];   
}