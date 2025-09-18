using FlockWise.Application.Models.Flock;

namespace FlockWise.Application.Mapping;

public class FlockProfile : Profile
{
    public FlockProfile()
    {
        CreateMap<Flock, FlockDto>();
        CreateMap<Sheep, SheepDto>();
        CreateMap<BirthRecord, BirthRecordDto>();
    }
}