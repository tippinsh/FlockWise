namespace FlockWise.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TreatmentRecordController : ControllerBase
{
    [HttpGet("{id:guid}/{userId:int}")]
    [Authorize]
    public async Task<IActionResult> GetById(Guid id, int userId)
    {
        return Ok();
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAllTreatmentRecords()
    {
        return Ok();
    }
}