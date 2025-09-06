using FlockWise.Application.Models.Flock;

namespace FlockWise.Application.Services;

public class FlockService(IFlockRepository flockRepository, IMapper mapper) : IFlockService
{
    public async Task<Result<FlockDto?>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var flock = await flockRepository.GetByIdAsync(id, cancellationToken);

            if (flock == null)
            {
                return Result<FlockDto?>.NotFound($"Flock with id {id} not found.");
            }
        
            var flockDto = mapper.Map<FlockDto>(flock);
            return Result<FlockDto?>.Ok(flockDto);
        }
        catch (Exception ex)
        {
            return Result<FlockDto?>.Error($"An error occurred while getting flock with id {id}: {ex.Message}", 500);
        }
    }

    public Task<FlockWithSheepDto?> GetByIdWithSheepAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}