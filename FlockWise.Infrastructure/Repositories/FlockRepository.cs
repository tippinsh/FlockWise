using FlockWise.Application.Interfaces;
using FlockWise.Application.Models.Flock;
using FlockWise.Application.Models.Requests;
using FlockWise.Core.Enums;
using FlockWise.Infrastructure.Persistence;
using FlockWise.Infrastructure.QueryBuilders;

namespace FlockWise.Infrastructure.Repositories;

public class FlockRepository (FlockWiseDbContext dbContext) : IFlockRepository
{
    public async Task<Flock?> GetByIdAsync(Guid id, FlockInclude include, CancellationToken cancellationToken = default)
    {
        try
        {
            var query = dbContext
                .Flocks
                .AsQueryable()
                .AsNoTracking();
        
            query = AddFlockIncludesToQuery(include, query);

            return await query.FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<IEnumerable<Flock>> GetPagedAsync(FlockListRequest request, CancellationToken cancellationToken = default)
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
        
            return await filteredQuery
                .Where(x => x.UserId == request.UserId)
                .ToListAsync(cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task AddAsync(AddFlockDto flock, CancellationToken cancellationToken = default)
    {
        try
        {
            var newFlock = new Flock
            {
                UserId = flock.UserId,
                Name = flock.Name,
                Location = flock.Location,
                EstablishedDateUtc = flock.EstablishedDateUtc,
                Breed = flock.Breed
            };
            
           await dbContext.Flocks.AddAsync(newFlock, cancellationToken);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
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