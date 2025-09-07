namespace FlockWise.Application.Models.Field;

public class FieldDto
{
    public Guid Id { get; set; }
    public double Size { get; set; }
    public string? Alias { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }
}