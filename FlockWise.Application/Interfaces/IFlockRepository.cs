using FlockWise.Core.Entities;

namespace FlockWise.Application.Interfaces;

public interface IFlockRepository
{
    Task<Flock?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Flock?> GetByIdWithSheepAsync(Guid id, CancellationToken cancellationToken = default);
    Task AddAsync(Flock flock, CancellationToken cancellationToken = default);
    Task RemoveAsync(Flock flock, CancellationToken cancellationToken = default);
    Task UpdateAsync(Flock flock, CancellationToken cancellationToken = default);   
    Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
}