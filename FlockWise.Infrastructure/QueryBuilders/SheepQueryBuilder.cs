using FlockWise.Core.Enums;

namespace FlockWise.Infrastructure.QueryBuilders;

public class SheepQueryBuilder(IQueryable<Sheep> sheepQuery)
{
    private IQueryable<Sheep> _sheepQuery = sheepQuery;

    public SheepQueryBuilder WithSearch(string? search)
    {
        if (!string.IsNullOrWhiteSpace(search))
        {
            _sheepQuery = _sheepQuery.Where(x => x.Breed.Contains(search) 
                                       || (x.Pedigree != null && x.Pedigree.Contains(search))
                                       || (x.FeetHealth != null && x.FeetHealth.Contains(search)));
        }

        return this;   
    }
    
    public SheepQueryBuilder WithBreed(string? breed)
    {
        if (!string.IsNullOrWhiteSpace(breed))
        {
            _sheepQuery = _sheepQuery.Where(s => s.Breed.Contains(breed));
        }
        return this;
    }
    
    public SheepQueryBuilder WithFlockId(Guid? flockId)
    {
        if (flockId.HasValue)
        {
            _sheepQuery = _sheepQuery.Where(s => s.FlockId == flockId.Value);
        }
        return this;
    }
    
    public SheepQueryBuilder WithSex(Sex? sex)
    {
        if (sex.HasValue)
        {
            _sheepQuery = _sheepQuery.Where(s => s.Sex == sex.Value);
        }
        return this;
    }
    
    public SheepQueryBuilder WithStatus(SheepStatus? status)
    {
        if (status.HasValue)
        {
            _sheepQuery = _sheepQuery.Where(s => s.Status == status.Value);
        }
        return this;
    }
    
    public SheepQueryBuilder WithLifeStage(LifeStage? lifeStage)
    {
        if (lifeStage.HasValue)
        {
            _sheepQuery = _sheepQuery.Where(s => s.LifeStage == lifeStage.Value);
        }
        return this;
    }

    public SheepQueryBuilder WithSorting(string? sortBy, string? sortDirection)
    {
        if (!string.IsNullOrWhiteSpace(sortBy))
        {
            _sheepQuery = sortBy.ToLower() switch
            {
                "breed" => sortDirection == "asc" 
                    ? _sheepQuery.OrderBy(x => x.Breed) 
                    : _sheepQuery.OrderByDescending(x => x.Breed),
                "sex" => sortDirection == "asc"
                    ? _sheepQuery.OrderBy(x => x.Sex)
                    : _sheepQuery.OrderByDescending(x => x.Sex),
                "status" => sortDirection == "asc"
                    ? _sheepQuery.OrderBy(x => x.Status)
                    : _sheepQuery.OrderByDescending(x => x.Status),
                "lifestage" => sortDirection == "asc" 
                    ? _sheepQuery.OrderBy(x => x.LifeStage) 
                    : _sheepQuery.OrderByDescending(x => x.LifeStage),
                _ => _sheepQuery.OrderBy(x => x.Id)
            };
        }
        else
        {
            _sheepQuery = _sheepQuery.OrderBy(x => x.Id);
        }

        return this;
    }
    
    public SheepQueryBuilder WithPagination(int page, int pageSize)
    {
        _sheepQuery = _sheepQuery.Skip((page - 1) * pageSize).Take(pageSize);
        return this;
    }
    
    public IQueryable<Sheep> Build() => _sheepQuery;
}