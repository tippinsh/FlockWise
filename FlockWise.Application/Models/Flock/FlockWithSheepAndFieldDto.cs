using FlockWise.Application.Models.Field;

namespace FlockWise.Application.Models.Flock;

public class FlockWithSheepAndFieldDto : FlockDto
{
    ICollection<SheepDto> Sheep { get; set; } = [];
    FieldDto? Field { get; set; }   
}