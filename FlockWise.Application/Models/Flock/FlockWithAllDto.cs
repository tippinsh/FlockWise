using FlockWise.Application.Models.Field;

namespace FlockWise.Application.Models.Flock;

public class FlockWithAllDto : FlockDto
{
    public ICollection<SheepDto> Sheep { get; set; } = [];
    public FieldDto? Field { get; set; }
    public ICollection<FlockNotesDto>? Notes { get; set; } = [];
}