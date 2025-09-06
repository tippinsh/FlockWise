using FlockWise.Application.Interfaces;
using FlockWise.Application.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FlockWise.API.Controllers;

[Controller]
public class FlockController(IFlockService flockService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, [FromQuery] FlockIncludeRequest request, CancellationToken cancellationToken = default)
    {
        var includeSheep = !string.IsNullOrEmpty(request.Include) && 
                           request.Include.Contains("sheep", StringComparison.OrdinalIgnoreCase);
    
        if (includeSheep)
        {
            var flockWithSheep = await flockService.GetByIdWithSheepAsync(id, cancellationToken);
            if (flockWithSheep == null)
            {
                return NotFound(new { message = $"Flock with id {id} not found." });
            }
            return Ok(flockWithSheep);
        }

        var flock = await flockService.GetByIdAsync(id, cancellationToken);
        if (flock == null)
        {
            return NotFound(new { message = $"Flock with id {id} not found." });
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