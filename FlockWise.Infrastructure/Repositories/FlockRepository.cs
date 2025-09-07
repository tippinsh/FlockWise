using FlockWise.Application.Interfaces;
using FlockWise.Core.Enums;
using FlockWise.Infrastructure.Persistence;

namespace FlockWise.Infrastructure.Repositories;

public class FlockRepository (FlockWiseDbContext dbContext) : IFlockRepository
{
    public async Task<Flock?> GetByIdAsync(Guid id, FlockInclude include, CancellationToken cancellationToken = default)
    {
        var query = dbContext.Flocks.AsQueryable();
        
        if (include.HasFlag(FlockInclude.Sheep))
            query = query.Include(f => f.Sheep);
        
        if (include.HasFlag(FlockInclude.Field))
            query = query.Include(f => f.Field);
        
        if (include.HasFlag(FlockInclude.FlockNotes))
            query = query.Include(f => f.Notes);
        
        return await query.FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
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