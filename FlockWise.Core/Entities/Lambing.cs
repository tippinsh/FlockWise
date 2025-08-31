namespace FlockWise.Core.Entities;

public class Lambing
{
    public Guid Id { get; set; }
    
    [Required]
    public required Sheep EweId { get; set; }

    [Required]
    public required Sheep TupId { get; set; }

    public DateTimeOffset? LambingDate { get; set; }

    public int NumberBorn { get; set; }

    public int NumberAlive { get; set; }

    public List<string> Notes { get; set; } = [];

    public AssistanceType AssistanceType { get; set; }

    public List<string>? AssistanceNotes { get; set; }

    public List<TreatmentRecord>? TreatmentRecords { get; set; }

    public Weight? AverageLambWeight { get; set; }
}