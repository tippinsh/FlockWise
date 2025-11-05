using FlockWise.Application.Models.Farm;

namespace FlockWise.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FarmController(IFarmService farmService) : ControllerBase
{
    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await farmService.GetByIdAsync(id);
        
        return !result.IsSuccess ? StatusCode(result.StatusCode, new { message = result.ErrorMessage }) : Ok(result.Data);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddFarm([FromBody] AddFarmDto farm, CancellationToken cancellationToken = default)
    {
        var result = await farmService.AddAsync(farm, cancellationToken);
        
        return !result.IsSuccess ? StatusCode(result.StatusCode, new { message = result.ErrorMessage }) 
            : StatusCode(201, new { success = true });
    }
}