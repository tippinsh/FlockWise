using FlockWise.Application.Models.Flock;

namespace FlockWise.API.Controllers;

[Controller]
public class FlockController(IFlockService flockService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] GetFlockRequest request, CancellationToken cancellationToken = default)
    {
        var flock = await flockService.GetByIdAsync(request, cancellationToken);
        
        if (flock == null)
        {
            return NotFound(new { message = $"Flock with id {request.Id} not found." });
        }
        
        return Ok(flock);
    }

    [HttpGet]
    public async Task<IActionResult> GetFlocks([FromQuery] FlockListRequest request, CancellationToken cancellationToken = default)
    {
        var flocks = await flockService.GetPagedAsync(request, cancellationToken);

        return Ok(flocks);
    }
    
    [HttpPost]
    public async Task<IActionResult> AddFlock([FromBody] AddFlockDto flock, CancellationToken cancellationToken = default)
    {
        await flockService.AddAsync(flock, cancellationToken);
        return Ok();
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateFlock([FromBody] UpdateFlockDto flock, CancellationToken cancellationToken = default)
    {
        await flockService.UpdateAsync(flock, cancellationToken);
        return Ok();
    }
    
    [HttpDelete]
    public async Task<IActionResult> RemoveFlock([FromQuery] Guid id, CancellationToken cancellationToken = default)
    {
        await flockService.RemoveAsync(id, cancellationToken);
        return Ok();   
    }
}