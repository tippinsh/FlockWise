using FlockWise.Core.Helpers;

namespace FlockWise.Core.Aggregates;

public class Flock(string name, string location, DateTimeOffset establishedDate, string breed, string notes)
{
    public Guid Id { get; init; } = SequentialGuidGenerator.NewSequentialGuid();
    public string? Name { get; set; } = name;
    public string? Location { get; set; } = location;
    public required List<Sheep> Sheep { get; set; }
    public DateTimeOffset EstablishedDate { get; init; } = establishedDate;
    public string? Breed { get; set; } = breed;
    public string? Notes { get; set; } = notes;
}