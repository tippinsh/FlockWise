using FlockWise.Core.Entities;

namespace FlockWise.Application.Interfaces;

public interface ISheepService
{
    Task<Sheep?> GetByIdAsync(GetSheepRequest request, CancellationToken cancellationToken = default);
    
    Task<IEnumerable<SheepDto>> GetPagedAsync(SheepListRequest request, CancellationToken cancellationToken = default);
}