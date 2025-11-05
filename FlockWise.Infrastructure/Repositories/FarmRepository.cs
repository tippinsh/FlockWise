using FlockWise.Application.Models.Farm;

namespace FlockWise.Infrastructure.Repositories;

public class FarmRepository(FlockWiseDbContext dbContext, ICurrentUserService currentUserService) : IFarmRepository
{
    public async Task<Result<Farm?>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        try
        {
            var query = dbContext.Farms.AsQueryable().AsNoTracking();
            
            var farm = await query.FirstOrDefaultAsync(cancellationToken);
            return Result<Farm?>.Ok(farm);
        }
        catch (Exception ex)
        {
            return Result<Farm?>.Error($"Failed to retrieve farm by Id {id}: {ex.Message}", 500);
        }
    }

    public async Task<Result<bool>> AddAsync(AddFarmDto farm, CancellationToken cancellationToken = default)
    {
        try
        {
            var newFarm = new Farm()
            {
                FlockMark = farm.FlockMark,
                Name = farm.Name
            };
            
            await dbContext.Farms.AddAsync(newFarm, cancellationToken);
            return Result<bool>.Ok(true);
        }
        catch (Exception ex)
        {
            return Result<bool>.Error($"Failed to add farm: {ex.Message}", 500);
        }
    }
}