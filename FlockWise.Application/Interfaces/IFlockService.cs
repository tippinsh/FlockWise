using FlockWise.Application.Models.Flock;

namespace FlockWise.Application.Interfaces;

public interface IFlockService
{
    Task<Result<FlockDto>> GetByIdAsync(Guid id, GetFlockRequest request, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<FlockDto>>> GetPagedAsync(FlockListRequest request, CancellationToken cancellationToken = default);
    Task<Result<bool>> AddAsync(AddFlockDto addFlockRequest, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(UpdateFlockDto flock, CancellationToken cancellationToken = default);
    Task<Result<bool>> RemoveAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<bool>> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
}