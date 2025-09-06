namespace FlockWise.Application.Models.Sheep;

public class BirthRecordDto
{
    public Guid Id { get; set; }
    public Guid SheepId { get; set; }
    public DateTimeOffset DateOfBirth { get; set; }
    public double WeightBornKgs { get; set; }
    public bool BottleFedLamb { get; set; }
    public Guid FatherId { get; set; }
    public Guid MotherId { get; set; }
    public string? BirthComplications { get; set; }
}