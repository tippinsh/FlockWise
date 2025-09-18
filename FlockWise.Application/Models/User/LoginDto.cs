using System.ComponentModel.DataAnnotations;

namespace FlockWise.Application.Models.User;

public class LoginDto
{
    [Required, EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }
}