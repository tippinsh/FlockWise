namespace FlockWise.API.Controllers;

[Controller]
public class SheepController(ISheepService sheepService) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] GetSheepRequest request, CancellationToken cancellationToken = default)
    {
        var sheep = await sheepService.GetByIdAsync(request, cancellationToken);
        if (sheep == null)
        {
            return NotFound(new { message = $"Sheep with id {request.Id} not found." });
        }
        return Ok(sheep);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPagedAsync([FromQuery] SheepListRequest request, CancellationToken cancellationToken = default)
    {
        var sheeps = await sheepService.GetPagedAsync(request, cancellationToken);
        return Ok(sheeps);
    }
}