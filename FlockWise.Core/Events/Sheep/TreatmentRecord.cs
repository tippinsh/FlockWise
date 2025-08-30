using System.ComponentModel.DataAnnotations;

namespace FlockWise.Core.Events.Sheep;

public class TreatmentRecord
{
    public int Id { get; set; }
    
    [Required]
    public int SheepId { get; set; }
    
    public DateTimeOffset DateOfTreatment { get; set; }
    
    [Required]
    public required string Complaint { get; set; }
    
    public string? Medication { get; set; }
    
    public string? Dose { get; set; }
    
    public string? Illness { get; set; }
    
    public string? VetAdvice { get; set; }
}