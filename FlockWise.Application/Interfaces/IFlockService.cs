using FlockWise.Application.Models.Flock;

namespace FlockWise.Application.Interfaces;

public interface IFlockService
{
    Task<Result<FlockDto?>> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<FlockWithSheepDto?> GetByIdWithSheepAsync(Guid id, CancellationToken cancellationToken = default);
}