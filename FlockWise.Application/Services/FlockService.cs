using FlockWise.Application.Models.Flock;

namespace FlockWise.Application.Services;

public class FlockService(IFlockRepository flockRepository, IMapper mapper) : IFlockService
{
    public async Task<FlockDto?> GetByIdAsync(GetFlockRequest request, CancellationToken cancellationToken = default)
    {
        var flock = await flockRepository.GetByIdAsync(request.Id, request.Include, cancellationToken);

        if (flock == null) return null;
        
        bool includeSheep = request.Include.HasFlag(FlockInclude.Sheep);
        bool includeField = request.Include.HasFlag(FlockInclude.Field);
        bool includeNotes = request.Include.HasFlag(FlockInclude.FlockNotes);
        
        return (includeSheep, includeField, includeNotes) switch
        {
            (true, true, true) => mapper.Map<FlockWithAllDto>(flock),
            (true, false, false) => mapper.Map<FlockWithSheepDto>(flock),
            (true, true, false) => mapper.Map<FlockWithSheepAndFieldDto>(flock),
            (true, false, true) => mapper.Map<FlockWithSheepAndNotesDto>(flock),
            _ => mapper.Map<FlockDto>(flock)
        };
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