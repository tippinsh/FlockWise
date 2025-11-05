using FlockWise.Application.Models.Farm;

namespace FlockWise.Application.Interfaces;

public interface IFarmService
{
    Task<Result<FarmDto>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<Result<bool>> AddAsync(AddFarmDto addFarmRequest, CancellationToken cancellationToken = default);
}