namespace FlockWise.Core.Entities;

public class TreatmentRecord
{
    public Guid Id { get; set; } = SequentialGuidGenerator.NewSequentialGuid();
    
    [Required]
    public Guid SheepId { get; set; }
    
    public DateTimeOffset DateOfTreatment { get; set; }
    
    [Required]
    public required string Complaint { get; set; }
    
    public string? Medication { get; set; }
    
    public string? Dose { get; set; }
    
    public string? Illness { get; set; }
    
    public string? VetAdvice { get; set; }
}