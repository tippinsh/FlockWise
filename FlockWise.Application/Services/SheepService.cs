namespace FlockWise.Application.Services;

public class SheepService(ISheepRepository sheepRepository, IMapper mapper, IUnitOfWork unitOfWork) : ISheepService
{
    public async Task<Result<SheepDto>> GetByIdAsync(Guid id, GetSheepRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await sheepRepository.GetByIdAsync(id, request.Include, cancellationToken);
        
        if (!result.IsSuccess)
        {
            return Result<SheepDto>.Error(result.ErrorMessage!, result.StatusCode);
        }

        if (result.Data == null)
        {
            return Result<SheepDto>.NotFound($"Sheep with ID {id} not found");
        }

        var sheepDto = mapper.Map<SheepDto>(result.Data);
        return Result<SheepDto>.Ok(sheepDto);
    }

    public async Task<Result<IEnumerable<SheepDto>>> GetPagedAsync(SheepListRequest request, CancellationToken cancellationToken = default)
    {
        var result = await sheepRepository.GetPagedAsync(request, cancellationToken);
        
        if (!result.IsSuccess)
        {
            return Result<IEnumerable<SheepDto>>.Error(result.ErrorMessage!, result.StatusCode);
        }

        var sheepDtos = mapper.Map<List<SheepDto>>(result.Data);
        return Result<IEnumerable<SheepDto>>.Ok(sheepDtos);
    }

    public async Task<Result<bool>> AddAsync(AddSheepDto addSheepRequest, CancellationToken cancellationToken = default)
    {
        var addResult = await sheepRepository.AddAsync(addSheepRequest, cancellationToken);
        
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
            return Result<bool>.Ok(true);
        }

        return Result<bool>.Error("Failed to save changes to database", 500);
    }

    public async Task<Result<bool>> UpdateAsync(UpdateSheepDto sheep, CancellationToken cancellationToken = default)
    {
        var existingSheepResult = await sheepRepository.GetByIdAsync(sheep.Id, SheepInclude.None, cancellationToken);
        
        if (!existingSheepResult.IsSuccess)
        {
            return Result<bool>.Error(existingSheepResult.ErrorMessage!, existingSheepResult.StatusCode);
        }

        if (existingSheepResult.Data == null)
        {
            return Result<bool>.NotFound($"Sheep with Id {sheep.Id} not found");
        }
        
        existingSheepResult.Data.FlockId = sheep.FlockId;
        existingSheepResult.Data.Pedigree = sheep.Pedigree;
        existingSheepResult.Data.FeetHealth = sheep.FeetHealth;
        existingSheepResult.Data.NumberOfTeeth = sheep.NumberOfTeeth;
        existingSheepResult.Data.Status = sheep.Status;
        existingSheepResult.Data.LifeStage = sheep.LifeStage;
        existingSheepResult.Data.SheepType = sheep.SheepType;
        
        var updateResult = await sheepRepository.UpdateAsync(existingSheepResult.Data, cancellationToken);
        
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
        var existingSheepResult = await sheepRepository.GetByIdAsync(id, SheepInclude.None, cancellationToken);
        
        if (!existingSheepResult.IsSuccess)
        {
            return Result<bool>.Error(existingSheepResult.ErrorMessage!, existingSheepResult.StatusCode);
        }

        if (existingSheepResult.Data == null)
        {
            return Result<bool>.NotFound($"Sheep with Id {id} not found");
        }

        var removeResult = await sheepRepository.RemoveAsync(existingSheepResult.Data, cancellationToken);
        
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
        return await sheepRepository.ExistsAsync(id, cancellationToken);
    }
}