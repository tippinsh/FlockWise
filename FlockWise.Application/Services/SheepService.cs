using FlockWise.Core.Entities;

namespace FlockWise.Application.Services;

public class SheepService : ISheepService
{
    public Task<Sheep?> GetByIdAsync(GetSheepRequest request, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}