namespace FlockWise.Core.Entities;

public class User
{
    public int Id { get; set; }
    [StringLength(100)]
    public string? FirstName { get; set; }
    [StringLength(100)]
    public string? LastName { get; set; }
    [Required, EmailAddress, StringLength(255)]
    public required string Email { get; set; }
    [Required]
    public required byte[] PasswordHash { get; set; }
    [Required]
    public required byte[] PasswordSalt { get; set; }
    public List<Flock> Flocks { get; set; } = [];
    public List<Field> Fields { get; set; } = [];
    public List<Sheep> Sheep { get; set; } = [];
    public List<Lambing> LambingRecords { get; set; } = [];
}