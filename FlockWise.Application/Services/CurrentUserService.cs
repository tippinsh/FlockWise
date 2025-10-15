using Microsoft.AspNetCore.Http;

namespace FlockWise.Application.Services;

public class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    public int UserId => int.Parse(httpContextAccessor.HttpContext?.User?
        .FindFirst(ClaimTypes.NameIdentifier)?.Value!);

    public int FarmId
    {
        get
        {
            var farmIdClaim = httpContextAccessor.HttpContext?.User
                .FindFirst("FarmId")?.Value;
            return farmIdClaim != null ? int.Parse(farmIdClaim) : 0;
        }
    }
}