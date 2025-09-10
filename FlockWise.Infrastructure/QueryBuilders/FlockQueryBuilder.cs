namespace FlockWise.Infrastructure.QueryBuilders;

public class FlockQueryBuilder(IQueryable<Flock> flockQuery)
{
    private IQueryable<Flock> _flockQuery = flockQuery;

    public FlockQueryBuilder WithSearch(string? search)
    {
        if (!string.IsNullOrWhiteSpace(search))
        {
            _flockQuery = _flockQuery.Where(x => x.Name != null && x.Name.Contains(search) 
                                       || x.Breed.ToString() == search
                                       || x.Location.ToString() == search);
        }

        return this;   
    }
    
    public FlockQueryBuilder WithName(string? name)
    {
        if (!string.IsNullOrWhiteSpace(name))
        {
            _flockQuery = _flockQuery.Where(f => f.Name != null && f.Name.Contains(name));
        }
        return this;
    }
    
    public FlockQueryBuilder WithDateRange(DateTimeOffset? from, DateTimeOffset? to)
    {
        if (from.HasValue && to.HasValue)
        {
            _flockQuery = _flockQuery.Where(x => x.EstablishedDateUtc >= from.Value && x.EstablishedDateUtc <= to.Value);
        }

        return this;
    }

    public FlockQueryBuilder WithSorting(string? sortBy, string? sortDirection)
    {
        if (!string.IsNullOrWhiteSpace(sortBy))
        {
            _flockQuery = sortBy.ToLower() switch
            {
                "name" => sortDirection == "asc" 
                    ? _flockQuery.OrderBy(x => x.Name) 
                    : _flockQuery.OrderByDescending(x => x.Name),
                "breed" => sortDirection == "asc"
                    ? _flockQuery.OrderBy(x => x.Breed)
                    : _flockQuery.OrderByDescending(x => x.Breed),
                "location" => sortDirection == "asc"
                    ? _flockQuery.OrderBy(x => x.Location)
                    : _flockQuery.OrderByDescending(x => x.Location),
                "establisheddate" => sortDirection == "asc" 
                    ? _flockQuery.OrderBy(x => x.EstablishedDateUtc) 
                    : _flockQuery.OrderByDescending(x => x.EstablishedDateUtc),
                _ => _flockQuery.OrderBy(x => x.Id)
            };
        }
        else
        {
            _flockQuery = _flockQuery.OrderBy(x => x.Id);
        }

        return this;
    }
    
    public FlockQueryBuilder WithPagination(int page, int pageSize)
    {
        _flockQuery = _flockQuery.Skip((page - 1) * pageSize).Take(pageSize);
        return this;
    }
    
    public IQueryable<Flock> Build() => _flockQuery;
}