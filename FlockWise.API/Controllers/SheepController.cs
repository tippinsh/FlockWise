using FlockWise.Application.Models.Sheep;

namespace FlockWise.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SheepController(ISheepService sheepService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> GetById(Guid id, [FromQuery] GetSheepRequest request, CancellationToken cancellationToken = default)
    {
        var result = await sheepService.GetByIdAsync(id, request, cancellationToken);
        
        return !result.IsSuccess ? StatusCode(result.StatusCode, new { message = result.ErrorMessage }) : Ok(result.Data);
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetPagedAsync([FromQuery] SheepListRequest request, CancellationToken cancellationToken = default)
    {
        var result = await sheepService.GetPagedAsync(request, cancellationToken);

        return !result.IsSuccess ? StatusCode(result.StatusCode, new { message = result.ErrorMessage }) : Ok(result.Data);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddSheep([FromBody] AddSheepDto sheep, CancellationToken cancellationToken = default)
    {
        var result = await sheepService.AddAsync(sheep, cancellationToken);
        
        return !result.IsSuccess ? StatusCode(result.StatusCode, new { message = result.ErrorMessage }) : StatusCode(201, new { success = true });
    }
    
    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateSheep([FromBody] UpdateSheepDto sheep, CancellationToken cancellationToken = default)
    {
        var result = await sheepService.UpdateAsync(sheep, cancellationToken);
        
        return !result.IsSuccess ? StatusCode(result.StatusCode, new { message = result.ErrorMessage }) : Ok(new { success = true });
    }
    
    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> RemoveSheep([FromQuery] Guid id, CancellationToken cancellationToken = default)
    {
        var result = await sheepService.RemoveAsync(id, cancellationToken);
        
        return !result.IsSuccess ? StatusCode(result.StatusCode, new { message = result.ErrorMessage }) : Ok(new { success = true });
    }
    
    [HttpHead("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> SheepExists(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await sheepService.ExistsAsync(id, cancellationToken);
        
        if (!result.IsSuccess)
        {
            return StatusCode(result.StatusCode);
        }

        return result.Data ? Ok() : NotFound();
    }
}