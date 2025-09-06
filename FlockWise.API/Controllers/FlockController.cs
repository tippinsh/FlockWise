using FlockWise.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FlockWise.API.Controllers;

[Controller]
public class FlockController(IFlockService flockService) : ControllerBase
{
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken = default)
    {
        var result = await flockService.GetByIdAsync(id, cancellationToken);

        if (result.StatusCode == StatusCodes.Status404NotFound)
        {
            return NotFound(new { errors = result.Errors });
        }

        return result.IsSuccess ? Ok(result.Data) : StatusCode(result.StatusCode, new { errors = result.Errors });
    }
}