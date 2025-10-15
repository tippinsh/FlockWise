namespace FlockWise.Application.Services;

public class UserService(
    IUserRepository userRepository,
    IMapper mapper,
    ITokenService tokenService,
    ILogger<UserService> logger)
    : IUserService
{
    public async Task<Result<AuthResponseDto>> RegisterAsync(RegisterDto registerDto)
    {
        try
        {
            // Check if the user already exists
            var existingUser = await userRepository.GetByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                return Result<AuthResponseDto>.Error("A user with this email already exists.");
            }

            // Hash password
            var (passwordHash, passwordSalt) = HashPassword(registerDto.Password);

            var user = new User
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            var createdUser = await userRepository.CreateAsync(user);
            var userDto = mapper.Map<UserDto>(createdUser);
            var token = tokenService.GenerateToken(createdUser);

            return Result<AuthResponseDto>.Ok(new AuthResponseDto
            {
                Token = token,
                User = userDto
            });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error registering user with email {Email}", registerDto.Email);
            return Result<AuthResponseDto>.Error("An error occurred while registering the user.");
        }
    }

    public async Task<Result<AuthResponseDto>> LoginAsync(LoginDto loginDto)
    {
        try
        {
            var user = await userRepository.GetByEmailAsync(loginDto.Email);
            if (user == null || !VerifyPassword(loginDto.Password, user.PasswordHash))
            {
                return Result<AuthResponseDto>.Error("Invalid email or password.");
            }

            var userDto = mapper.Map<UserDto>(user);
            var token = tokenService.GenerateToken(user);

            return Result<AuthResponseDto>.Ok(new AuthResponseDto
            {
                Token = token,
                User = userDto
            });
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error logging in user with email {Email}", loginDto.Email);
            return Result<AuthResponseDto>.Error("An error occurred while logging in.");
        }
    }

    public async Task<Result<UserDto>> GetUserByIdAsync(int userId)
    {
        try
        {
            var user = await userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return Result<UserDto>.NotFound("User not found.");
            }

            var userDto = mapper.Map<UserDto>(user);
            return Result<UserDto>.Ok(userDto);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error getting user with Id: {UserId}", userId);
            return Result<UserDto>.Error("An error occurred while retrieving the user.");
        }
    }

    public async Task<Result<bool>> UserExistsAsync(string email)
    {
        try
        {
            var user = await userRepository.GetByEmailAsync(email);
            return Result<bool>.Ok(user != null);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error checking if user exists with email {Email}", email);
            return Result<bool>.Error("An error occurred while checking user existence.");
        }
    }

    private static (byte[] hash, byte[] salt) HashPassword(string password)
    {
        var salt = BCrypt.Net.BCrypt.GenerateSalt();
        var hash = BCrypt.Net.BCrypt.HashPassword(password, salt);
        return (Encoding.UTF8.GetBytes(hash), Encoding.UTF8.GetBytes(salt));
    }

    private static bool VerifyPassword(string password, byte[] hash)
    {
        var hashString = Encoding.UTF8.GetString(hash);
        return BCrypt.Net.BCrypt.Verify(password, hashString);
    }
}