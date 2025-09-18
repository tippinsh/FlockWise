namespace FlockWise.Application.Models.Flock;

public class UpdateFlockDto
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public Location? Location { get; set; }
    public Breed? Breed { get; set; }
    public Guid? FieldId { get; set; }
}