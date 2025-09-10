using FlockWise.Application.Models.Flock;
using FlockWise.Core.Entities;

namespace FlockWise.Application.Interfaces;

public interface IFlockRepository
{
    Task<Flock?> GetByIdAsync(Guid id, FlockInclude include, CancellationToken cancellationToken = default);
    Task<IEnumerable<Flock>> GetPagedAsync(FlockListRequest request, CancellationToken cancellationToken = default);   
    Task AddAsync(AddFlockDto flock, CancellationToken cancellationToken = default);
    Task RemoveAsync(Flock flock, CancellationToken cancellationToken = default);
    Task UpdateAsync(Flock flock, CancellationToken cancellationToken = default);   
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
}