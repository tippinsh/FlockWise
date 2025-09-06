using FlockWise.Application.Models.Flock;

namespace FlockWise.Application.Services;

public class FlockService(IFlockRepository flockRepository, IMapper mapper) : IFlockService
{
    public async Task<FlockDto?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var flock = await flockRepository.GetByIdAsync(id, cancellationToken);
        return flock == null ? null : mapper.Map<FlockDto>(flock);
    }

    public async Task<FlockWithSheepDto?> GetByIdWithSheepAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var flock = await flockRepository.GetByIdWithSheepAsync(id, cancellationToken);
        return flock == null ? null : mapper.Map<FlockWithSheepDto>(flock);
    }

    public Task<IEnumerable<FlockDto>> GetPagedAsync(FlockListRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task AddAsync(AddFlockDto flock, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(UpdateFlockDto flock, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}