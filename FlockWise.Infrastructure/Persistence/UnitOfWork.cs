using FlockWise.Application.Interfaces;

namespace FlockWise.Infrastructure.Persistence;

public class UnitOfWork(FlockWiseDbContext context) : IUnitOfWork
{
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) 
        => context.SaveChangesAsync(cancellationToken);
}