namespace FlockWise.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FlockController(IFlockService flockService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> GetById(Guid id, [FromQuery] GetFlockRequest request, CancellationToken cancellationToken = default)
    {
        var result = await flockService.GetByIdAsync(id, request, cancellationToken);
        
        return !result.IsSuccess ? StatusCode(result.StatusCode, new { message = result.ErrorMessage }) : Ok(result.Data);
    }

    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetFlocks([FromQuery] FlockListRequest request, CancellationToken cancellationToken = default)
    {
        var result = await flockService.GetPagedAsync(request, cancellationToken);

        return !result.IsSuccess ? StatusCode(result.StatusCode, new { message = result.ErrorMessage }) : Ok(result.Data);
    }
    
    [HttpPost]
    [Authorize]
    public async Task<IActionResult> AddFlock([FromBody] AddFlockDto flock, CancellationToken cancellationToken = default)
    {
        var result = await flockService.AddAsync(flock, cancellationToken);
        
        return !result.IsSuccess ? StatusCode(result.StatusCode, new { message = result.ErrorMessage }) : StatusCode(201, new { success = true });
    }
    
    [HttpPut]
    [Authorize]
    public async Task<IActionResult> UpdateFlock([FromBody] UpdateFlockDto flock, CancellationToken cancellationToken = default)
    {
        var result = await flockService.UpdateAsync(flock, cancellationToken);
        
        return !result.IsSuccess ? StatusCode(result.StatusCode, new { message = result.ErrorMessage }) : Ok(new { success = true });
    }
    
    [HttpDelete]
    [Authorize]
    public async Task<IActionResult> RemoveFlock([FromQuery] Guid id, CancellationToken cancellationToken = default)
    {
        var result = await flockService.RemoveAsync(id, cancellationToken);
        
        return !result.IsSuccess ? StatusCode(result.StatusCode, new { message = result.ErrorMessage }) : Ok(new { success = true });
    }
    
    [HttpHead("{id:guid}")]
    [Authorize]
    public async Task<IActionResult> FlockExists(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await flockService.ExistsAsync(id, cancellationToken);
        
        if (!result.IsSuccess)
        {
            return StatusCode(result.StatusCode);
        }

        return result.Data ? Ok() : NotFound();
    }
}