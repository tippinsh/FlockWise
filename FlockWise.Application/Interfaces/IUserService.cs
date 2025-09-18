namespace FlockWise.Application.Interfaces;

public interface IUserService
{
    Task<Result<AuthResponseDto>> RegisterAsync(RegisterDto registerDto);
    Task<Result<AuthResponseDto>> LoginAsync(LoginDto loginDto);
    Task<Result<UserDto>> GetUserByIdAsync(int userId);
    Task<Result<bool>> UserExistsAsync(string email);
}