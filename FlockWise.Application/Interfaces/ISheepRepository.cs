namespace FlockWise.Application.Interfaces;

public interface ISheepRepository
{
    Task<Result<Sheep?>> GetByIdAsync(Guid id, SheepInclude include, CancellationToken cancellationToken = default);
    Task<Result<IEnumerable<Sheep>>> GetPagedAsync(SheepListRequest request, CancellationToken cancellationToken = default);   
    Task<Result<bool>> AddAsync(AddSheepDto sheep, CancellationToken cancellationToken = default);
    Task<Result<bool>> RemoveAsync(Sheep sheep, CancellationToken cancellationToken = default);
    Task<Result<bool>> UpdateAsync(Sheep sheep, CancellationToken cancellationToken = default);   
    Task<Result<bool>> ExistsAsync(Guid id, CancellationToken cancellationToken = default);
}