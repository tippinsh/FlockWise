using FlockWise.Application.Models.Farm;

namespace FlockWise.Application.Services;

public class FarmService(IFarmRepository farmRepository, IMapper mapper, IUnitOfWork unitOfWork) : IFarmService
{
    public async Task<Result<FarmDto>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
    {
        var result = await farmRepository.GetByIdAsync(id, cancellationToken);

        if (result is { IsSuccess: false, ErrorMessage: not null })
        {
            return Result<FarmDto>.Error(result.ErrorMessage, result.StatusCode);
        }

        if (result.Data == null)
        {
            return Result<FarmDto>.NotFound($"Farm with Id {id} not found");
        }
        
        var farmDto = mapper.Map<FarmDto>(result.Data);
        return Result<FarmDto>.Ok(farmDto);   
    }

    public async Task<Result<bool>> AddAsync(AddFarmDto addFarmRequest, CancellationToken cancellationToken = default)
    {
        var addResult = await farmRepository.AddAsync(addFarmRequest, cancellationToken);

        if (addResult is { IsSuccess: false, ErrorMessage: not null })
        {
            return Result<bool>.Error(addResult.ErrorMessage, addResult.StatusCode);
        }

        var saveResult = await unitOfWork.SaveChangesAsync(cancellationToken);

        if (saveResult is { IsSuccess: false, ErrorMessage: not null })
        {
            return Result<bool>.Error(saveResult.ErrorMessage, saveResult.StatusCode);
        }

        if (saveResult.Data > 0)
        {
            return Result<bool>.Ok(true, 201);
        }
        
        return Result<bool>.Error("Failed to save changes to database", 500);
    }
}