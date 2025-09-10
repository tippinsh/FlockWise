namespace FlockWise.Application.Models.Flock;

public class AddFlockDto
{
    public int UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public Location Location { get; set; }
    public Breed Breed { get; set; }
    public DateTimeOffset EstablishedDateUtc { get; set; }
}   