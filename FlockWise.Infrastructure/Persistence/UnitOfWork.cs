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

    public async Task<Result<int>> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var result = await context.SaveChangesAsync(cancellationToken);

            if (_transaction != null)
            {
                await _transaction.CommitAsync(cancellationToken);
                await _transaction.DisposeAsync();
                _transaction = null;
            }

            return Result<int>.Ok(result);
        }
        catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("foreign key constraint") == true)
        {
            await RollbackIfNeeded();
            return Result<int>.Error("Invalid reference provided - the referenced record does not exist", 400);
        }
        catch (DbUpdateException ex) when (ex.InnerException?.Message.Contains("unique constraint") == true)
        {
            await RollbackIfNeeded();
            return Result<int>.Error("A record with this information already exists", 409);
        }
        catch (DbUpdateException ex)
        {
            await RollbackIfNeeded();
            return Result<int>.Error($"Database update failed: {ex.Message}", 500);
        }
        catch (Exception ex)
        {
            await RollbackIfNeeded();
            return Result<int>.Error($"Failed to save changes: {ex.Message}", 500);
        }
    }

    private async Task RollbackIfNeeded()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
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