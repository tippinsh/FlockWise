using FlockWise.Application.Models.Flock;

namespace FlockWise.Application.Services;

public class FlockService(IFlockRepository flockRepository, IMapper mapper, IUnitOfWork unitOfWork) : IFlockService
{
    public async Task<Result<FlockDto>> GetByIdAsync(Guid id, GetFlockRequest request, CancellationToken cancellationToken = default)
    {
        var result = await flockRepository.GetByIdAsync(id, request.Include, cancellationToken);
        
        if (!result.IsSuccess)
        {
            return Result<FlockDto>.Error(result.ErrorMessage!, result.StatusCode);
        }

        if (result.Data == null)
        {
            return Result<FlockDto>.NotFound($"Flock with Id {id} not found");
        }

        var flockDto = mapper.Map<FlockDto>(result.Data);
        return Result<FlockDto>.Ok(flockDto);
    }

    public async Task<Result<IEnumerable<FlockDto>>> GetPagedAsync(FlockListRequest request, CancellationToken cancellationToken = default)
    {
        var result = await flockRepository.GetPagedAsync(request, cancellationToken);
        
        if (!result.IsSuccess)
        {
            return Result<IEnumerable<FlockDto>>.Error(result.ErrorMessage!, result.StatusCode);
        }

        var flockDtos = mapper.Map<List<FlockDto>>(result.Data);
        return Result<IEnumerable<FlockDto>>.Ok(flockDtos);
    }

    public async Task<Result<bool>> AddAsync(AddFlockDto addFlockRequest, CancellationToken cancellationToken = default)
    {
        var addResult = await flockRepository.AddAsync(addFlockRequest, cancellationToken);
        
        if (!addResult.IsSuccess)
        {
            return Result<bool>.Error(addResult.ErrorMessage!, addResult.StatusCode);
        }

        var saveResult = await unitOfWork.SaveChangesAsync(cancellationToken);
        
        if (!saveResult.IsSuccess)
        {
            return Result<bool>.Error(saveResult.ErrorMessage!, saveResult.StatusCode);
        }
        
        if (saveResult.Data > 0)
        {
            return Result<bool>.Ok(true, 201);
        }

        return Result<bool>.Error("Failed to save changes to database", 500);
    }

    public async Task<Result<bool>> UpdateAsync(UpdateFlockDto flock, CancellationToken cancellationToken = default)
    {
        var existingFlockResult = await flockRepository.GetByIdAsync(flock.Id, FlockInclude.None, cancellationToken);
        
        if (!existingFlockResult.IsSuccess)
        {
            return Result<bool>.Error(existingFlockResult.ErrorMessage!, existingFlockResult.StatusCode);
        }

        if (existingFlockResult.Data == null)
        {
            return Result<bool>.NotFound($"Flock with Id {flock.Id} not found");
        }

        existingFlockResult.Data.Name = flock.Name;
        existingFlockResult.Data.Location = flock.Location;
        existingFlockResult.Data.Breed = flock.Breed;
        existingFlockResult.Data.FieldId = flock.FieldId;
        
        var updateResult = await flockRepository.UpdateAsync(existingFlockResult.Data);
        
        if (!updateResult.IsSuccess)
        {
            return Result<bool>.Error(updateResult.ErrorMessage!, updateResult.StatusCode);
        }

        var saveResult = await unitOfWork.SaveChangesAsync(cancellationToken);
        
        if (!saveResult.IsSuccess)
        {
            return Result<bool>.Error(saveResult.ErrorMessage!, saveResult.StatusCode);
        }
        
        if (saveResult.Data > 0)
        {
            return Result<bool>.Ok(true);
        }

        return Result<bool>.Error("Failed to save changes to database", 500);
    }

    public async Task<Result<bool>> RemoveAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var existingFlockResult = await flockRepository.GetByIdAsync(id, FlockInclude.None, cancellationToken);
        
        if (!existingFlockResult.IsSuccess)
        {
            return Result<bool>.Error(existingFlockResult.ErrorMessage!, existingFlockResult.StatusCode);
        }

        if (existingFlockResult.Data == null)
        {
            return Result<bool>.NotFound($"Flock with Id {id} not found");
        }

        var removeResult = await flockRepository.RemoveAsync(existingFlockResult.Data);
        
        if (!removeResult.IsSuccess)
        {
            return Result<bool>.Error(removeResult.ErrorMessage!, removeResult.StatusCode);
        }

        var saveResult = await unitOfWork.SaveChangesAsync(cancellationToken);
        
        if (!saveResult.IsSuccess)
        {
            return Result<bool>.Error(saveResult.ErrorMessage!, saveResult.StatusCode);
        }

        if (saveResult.Data > 0)
        {
            return Result<bool>.Ok(true);
        }

        return Result<bool>.Error("Failed to save changes to database", 500);
    }

    public async Task<Result<bool>> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await flockRepository.ExistsAsync(id, cancellationToken);
    }
}