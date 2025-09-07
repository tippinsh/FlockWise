using FlockWise.Core.Entities;

namespace FlockWise.Application.Interfaces;

public interface ISheepService
{
    Task<Sheep?> GetByIdAsync(GetSheepRequest request, CancellationToken cancellationToken = default);
}