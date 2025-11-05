using FlockWise.Application.Models.Sheep;
using FlockWise.Application.Models.Requests;
using FlockWise.Core.Enums;
using FlockWise.Infrastructure.QueryBuilders;

namespace FlockWise.Infrastructure.Repositories;

public class SheepRepository(FlockWiseDbContext dbContext) : ISheepRepository
{
    public async Task<Result<Sheep?>> GetByIdAsync(Guid id, SheepInclude include, CancellationToken cancellationToken = default)
    {
        try
        {
            var query = dbContext
                .Sheep
                .AsQueryable()
                .AsNoTracking();
        
            query = AddSheepIncludesToQuery(include, query);

            var sheep = await query.FirstOrDefaultAsync(s => s.Id == id, cancellationToken);
            return Result<Sheep?>.Ok(sheep);
        }
        catch (Exception ex)
        {
            return Result<Sheep?>.Error($"Failed to retrieve sheep by ID {id}: {ex.Message}", 500);
        }
    }

    public async Task<Result<IEnumerable<Sheep>>> GetPagedAsync(SheepListRequest request, CancellationToken cancellationToken = default)
    {
        try
        {
            var query = dbContext
                .Sheep
                .AsQueryable()
                .AsNoTracking();
        
            query = AddSheepIncludesToQuery(request.Include, query);
        
            var filteredQuery = new SheepQueryBuilder(query)
                .WithBreed(request.Breed)
                .WithSearch(request.Search)
                .WithFlockId(request.FlockId)
                .WithSex(request.Sex)
                .WithStatus(request.Status)
                .WithLifeStage(request.LifeStage)
                .WithPagination(request.Page, request.PageSize)
                .WithSorting(request.SortBy, request.SortDirection)
                .Build();
        
            var sheep = await filteredQuery
                .Where(x => x.FarmId == request.FarmId)
                .ToListAsync(cancellationToken);

            return Result<IEnumerable<Sheep>>.Ok(sheep);
        }
        catch (Exception ex)
        {
            return Result<IEnumerable<Sheep>>.Error($"Failed to retrieve paged sheep: {ex.Message}", 500);
        }
    }

    public async Task<Result<bool>> AddAsync(AddSheepDto sheep, CancellationToken cancellationToken = default)
    {
        try
        {
            var newSheep = new Sheep
            {
                FarmId = sheep.FarmId,
                FlockId = sheep.FlockId,
                Breed = sheep.Breed,
                Pedigree = sheep.Pedigree,
                Sex = sheep.Sex,
                FeetHealth = sheep.FeetHealth,
                NumberOfTeeth = sheep.NumberOfTeeth,
                Status = sheep.Status,
                LifeStage = sheep.LifeStage,
                SheepType = sheep.SheepType
            };
            
            await dbContext.Sheep.AddAsync(newSheep, cancellationToken);
            return Result<bool>.Ok(true);
        }
        catch (Exception ex)
        {
            return Result<bool>.Error($"Failed to add sheep: {ex.Message}", 500);
        }
    }

    public Task<Result<bool>> RemoveAsync(Sheep sheep, CancellationToken cancellationToken = default)
    {
        try
        {
            dbContext.Sheep.Remove(sheep);
            return Task.FromResult(Result<bool>.Ok(true));
        }
        catch (Exception ex)
        {
            return Task.FromResult(Result<bool>.Error($"Failed to remove sheep: {ex.Message}", 500));
        }
    }

    public Task<Result<bool>> UpdateAsync(Sheep sheep, CancellationToken cancellationToken = default)
    {
        try
        {
            dbContext.Sheep.Update(sheep);
            return Task.FromResult(Result<bool>.Ok(true));
        }
        catch (Exception ex)
        {
            return Task.FromResult(Result<bool>.Error($"Failed to update sheep: {ex.Message}", 500));
        }
    }

    public async Task<Result<bool>> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var exists = await dbContext.Sheep
                .AsNoTracking()
                .AnyAsync(s => s.Id == id, cancellationToken);
                
            return Result<bool>.Ok(exists);
        }
        catch (Exception ex)
        {
            return Result<bool>.Error($"Failed to check if sheep exists: {ex.Message}", 500);
        }
    }
    
    private static IQueryable<Sheep> AddSheepIncludesToQuery(SheepInclude include, IQueryable<Sheep> query)
    {
        if (include.HasFlag(SheepInclude.Flock))
            query = query.Include(s => s.Flock);
        
        if (include.HasFlag(SheepInclude.BirthRecords))
            query = query.Include(s => s.BirthRecord);
        
        if (include.HasFlag(SheepInclude.WeightHistory))
            query = query.Include(s => s.Weights);
        
        return query;
    }
}