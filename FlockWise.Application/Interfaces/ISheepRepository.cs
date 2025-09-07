using FlockWise.Core.Entities;

namespace FlockWise.Application.Interfaces;

public interface ISheepRepository
{
    Task<Sheep?> GetByIdAsync(Guid id, SheepInclude include, CancellationToken cancellationToken = default);
}