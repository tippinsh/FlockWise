using FlockWise.Application.Interfaces;
using FlockWise.Core.Enums;

namespace FlockWise.Infrastructure.Repositories;

public class SheepRepository : ISheepRepository
{
    public Task<Sheep?> GetByIdAsync(Guid id, SheepInclude include, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}