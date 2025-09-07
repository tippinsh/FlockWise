using FlockWise.Application.Models.Flock;

namespace FlockWise.Application.Interfaces;

public interface IFlockService
{
    Task<FlockDto?> GetByIdAsync(GetFlockRequest request, CancellationToken cancellationToken = default);
    Task<IEnumerable<FlockDto>> GetPagedAsync(FlockListRequest request, CancellationToken cancellationToken = default);   
    Task AddAsync(AddFlockDto flock, CancellationToken cancellationToken = default);
    Task UpdateAsync(UpdateFlockDto flock, CancellationToken cancellationToken = default);
    Task RemoveAsync(Guid id, CancellationToken cancellationToken = default);
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
}