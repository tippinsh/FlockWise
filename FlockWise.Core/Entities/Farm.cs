namespace FlockWise.Core.Entities;

public class Farm
{
    public int Id { get; set; }
    
    [StringLength(100)]
    public string FlockMark { get; set; } = string.Empty;
    
    [Required, StringLength(100)]
    public string Name { get; set; } = string.Empty;
    
    // Navigation Properties
    public List<User> Users { get; set; }
    public List<Flock> Flocks { get; set; }
    public List<Field> Fields { get; set; }
}