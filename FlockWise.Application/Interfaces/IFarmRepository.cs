using FlockWise.Application.Models.Farm;

namespace FlockWise.Application.Interfaces;

public interface IFarmRepository
{
    Task<Result<Farm?>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<bool>> AddAsync(AddFarmDto farm, CancellationToken cancellationToken = default);   
}