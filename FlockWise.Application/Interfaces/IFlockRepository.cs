using FlockWise.Application.Models.Flock;

namespace FlockWise.Application.Interfaces;

public interface IFlockRepository
{
    Task<Result<Flock?>> GetByIdAsync(Guid id, FlockInclude include, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<Flock>>> GetPagedAsync(FlockListRequest request, CancellationToken cancellationToken = default);   
    Task<Result<bool>> AddAsync(AddFlockDto flock, CancellationToken cancellationToken = default);
    Task<Result<bool>> RemoveAsync(Flock flock);
    Task<Result<bool>> UpdateAsync(Flock flock);   
    Task<Result<bool>> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
}