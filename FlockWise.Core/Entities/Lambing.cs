namespace FlockWise.Core.Entities;

public class Lambing
{
    public Guid Id { get; set; } = SequentialGuidGenerator.NewSequentialGuid();
    [Required]
    public required Guid EweId { get; set; }
    [Required]
    public required Guid TupId { get; set; }
    public DateTimeOffset LambingDate { get; set; }
    public int? NumberBorn { get; set; }
    public int? NumberAlive { get; set; }
    public ICollection<LambingNote> Notes { get; set; } = [];
    public AssistanceType? AssistanceType { get; set; }
    public ICollection<LambingNote>? AssistanceNotes { get; set; }
    public List<TreatmentRecord>? TreatmentRecords { get; set; }
}