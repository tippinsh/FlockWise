using FlockWise.Application.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace FlockWise.Infrastructure.Persistence;

public class UnitOfWork(FlockWiseDbContext context) : IUnitOfWork
{
    private IDbContextTransaction? _transaction;

    public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction != null)
        {
            throw new InvalidOperationException("Transaction already started");
        }

        _transaction = await context.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await context.SaveChangesAsync(cancellationToken);

            if (_transaction == null)
            {
                return result;
            }

            await _transaction.CommitAsync(cancellationToken);
            await _transaction.DisposeAsync();
            _transaction = null;

            return result;
        }
        catch
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync(cancellationToken);
                await _transaction.DisposeAsync();
                _transaction = null;
            }

            throw;
        }
    }

    public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync(cancellationToken);
            await _transaction.DisposeAsync();
            _transaction = null;       
        }
    }

    public void Dispose()
    {
        context.Dispose();
    }
}