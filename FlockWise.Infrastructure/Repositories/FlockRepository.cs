using FlockWise.Application.Interfaces;
using FlockWise.Application.Models;
using FlockWise.Application.Models.Flock;
using FlockWise.Application.Models.Requests;
using FlockWise.Core.Enums;
using FlockWise.Infrastructure.Persistence;
using FlockWise.Infrastructure.QueryBuilders;

namespace FlockWise.Infrastructure.Repositories;

public class FlockRepository (FlockWiseDbContext dbContext, ICurrentUserService currentUserService) : IFlockRepository
{
    private readonly int _farmId = currentUserService.FarmId;
    
    public async Task<Result<Flock?>> GetByIdAsync(Guid id, FlockInclude include, CancellationToken cancellationToken = default)
    {
        try
        {
            var query = dbContext
                .Flocks
                .AsQueryable()
                .AsNoTracking();
        
            query = AddFlockIncludesToQuery(include, query);

            var flock = await query.FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
            return Result<Flock?>.Ok(flock);
        }
        catch (Exception ex)
        {
            return Result<Flock?>.Error($"Failed to retrieve flock by ID {id}: {ex.Message}", 500);
        }
    }

    public async Task<Result<IEnumerable<Flock>>> GetPagedAsync(FlockListRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var query = dbContext
                .Flocks
                .AsQueryable()
                .AsNoTracking();
        
            query = AddFlockIncludesToQuery(request.Include, query);
        
            var filteredQuery = new FlockQueryBuilder(query)
                .WithName(request.Name)
                .WithSearch(request.Search)
                .WithDateRange(request.CreatedAfter, request.CreatedBefore)
                .WithPagination(request.Page, request.PageSize)
                .WithSorting(request.SortBy, request.SortDirection)
                .Build();
        
            var flocks = await filteredQuery
                .Where(x => x.FarmId == _farmId)
                .ToListAsync(cancellationToken);

            return Result<IEnumerable<Flock>>.Ok(flocks);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<Flock>>.Error($"Failed to retrieve paged flocks: {ex.Message}", 500);
        }
    }

    public async Task<Result<bool>> AddAsync(AddFlockDto flock, CancellationToken cancellationToken = default)
    {
        try
        {
            var newFlock = new Flock
            {
                FarmId = _farmId,
                Name = flock.Name,
                Location = flock.Location,
                EstablishedDateUtc = flock.EstablishedDateUtc,
                Breed = flock.Breed
            };
            
            await dbContext.Flocks.AddAsync(newFlock, cancellationToken);
            return Result<bool>.Ok(true);
        }
        catch (Exception ex)
        {
            return Result<bool>.Error($"Failed to add flock: {ex.Message}", 500);
        }
    }

    public Task<Result<bool>> RemoveAsync(Flock flock)
    {
        try
        {
            dbContext.Flocks.Remove(flock);
            return Task.FromResult(Result<bool>.Ok(true));
        }
        catch (Exception ex)
        {
            return Task.FromResult(Result<bool>.Error($"Failed to remove flock: {ex.Message}", 500));
        }
    }

    public Task<Result<bool>> UpdateAsync(Flock flock)
    {
        try
        {
            dbContext.Flocks.Update(flock);
            return Task.FromResult(Result<bool>.Ok(true));
        }
        catch (Exception ex)
        {
            return Task.FromResult(Result<bool>.Error($"Failed to update flock: {ex.Message}", 500));
        }
    }

    public async Task<Result<bool>> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var exists = await dbContext.Flocks
                .AsNoTracking()
                .AnyAsync(f => f.Id == id, cancellationToken);
                
            return Result<bool>.Ok(exists);
        }
        catch (Exception ex)
        {
            return Result<bool>.Error($"Failed to check if flock exists: {ex.Message}", 500);
        }
    }
    
    private static IQueryable<Flock> AddFlockIncludesToQuery(FlockInclude include, IQueryable<Flock> query)
    {
        if (include.HasFlag(FlockInclude.Sheep))
            query = query.Include(f => f.Sheep);
        
        if (include.HasFlag(FlockInclude.Field))
            query = query.Include(f => f.Field);
        
        if (include.HasFlag(FlockInclude.FlockNotes))
            query = query.Include(f => f.Notes);
        
        return query;
    }
}