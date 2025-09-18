namespace FlockWise.Application.Interfaces;

public interface ISheepService
{
    Task<Result<SheepDto>> GetByIdAsync(Guid id, GetSheepRequest request, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<SheepDto>>> GetPagedAsync(SheepListRequest request, CancellationToken cancellationToken = default);
    Task<Result<bool>> AddAsync(AddSheepDto addSheepRequest, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(UpdateSheepDto sheep, CancellationToken cancellationToken = default);
    Task<Result<bool>> RemoveAsync(Guid id, CancellationToken cancellationToken = default);
    Task<Result<bool>> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
}