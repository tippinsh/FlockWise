namespace FlockWise.Application.Interfaces;

public interface ITokenService
{
    string GenerateToken(User user);

    int? GetUserIdFromToken(string token);
}