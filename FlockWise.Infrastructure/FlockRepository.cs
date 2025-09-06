using FlockWise.Application.Interfaces;
using FlockWise.Infrastructure.Persistence;

namespace FlockWise.Infrastructure;

public class FlockRepository (FlockWiseDbContext dbContext) : IFlockRepository
{
    public async Task<Flock?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Flocks.FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
    }

    public async Task<Flock?> GetByIdWithSheepAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await dbContext.Flocks.Include(f => f.Sheep).FirstOrDefaultAsync(f => f.Id == id, cancellationToken);       
    }

    public Task AddAsync(Flock flock, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task RemoveAsync(Flock flock, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Flock flock, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}