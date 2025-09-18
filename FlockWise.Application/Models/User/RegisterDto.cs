using System.ComponentModel.DataAnnotations;

namespace FlockWise.Application.Models.User;

public class RegisterDto
{
    [StringLength(100)]
    public string? FirstName { get; set; }

    [StringLength(100)]
    public string? LastName { get; set; }
    
    [Required, EmailAddress, StringLength(255)]
    public required string Email { get; set; }

    [Required, MinLength(6)]
    public required string Password { get; set; }
}