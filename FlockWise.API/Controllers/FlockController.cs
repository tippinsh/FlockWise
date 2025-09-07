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
        var result = await flockService.GetPagedAsync(request, cancellationToken);
        return Ok(result);
    }
}