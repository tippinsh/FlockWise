namespace FlockWise.Core.Entities;

public class LambingNote
{
    public Guid Id { get; set; }
    
    public Guid LambingId { get; set; }
    
    [Required, StringLength(255)]
    public string Note { get; set; } = string.Empty;
    
    public DateTimeOffset LastModified { get; set; }
    
    // Navigation properties
    public Lambing? Lambing { get; set; }
}