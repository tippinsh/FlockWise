using FlockWise.Application.Models.Flock;

namespace FlockWise.Application.Services;

public class FlockService(IFlockRepository flockRepository, IMapper mapper, IUnitOfWork unitOfWork) : IFlockService
{
    public async Task<FlockDto?> GetByIdAsync(GetFlockRequest request, CancellationToken cancellationToken = default)
    {
        var flock = await flockRepository.GetByIdAsync(request.Id, request.Include, cancellationToken);

        return flock == null ? null : mapper.Map<FlockDto>(flock);
    }

    public async Task<IEnumerable<FlockDto>> GetPagedAsync(FlockListRequest request, CancellationToken cancellationToken = default)
    {
        var flocks = await flockRepository.GetPagedAsync(request, cancellationToken);
        
        return mapper.Map<List<FlockDto>>(flocks);    
    }

    public async Task AddAsync(AddFlockDto addFlockRequest, CancellationToken cancellationToken = default)
    {
        await flockRepository.AddAsync(addFlockRequest, cancellationToken);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);   
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