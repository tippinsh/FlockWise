namespace FlockWise.Application.Models.Requests;

public class FlockListRequest : BaseFilterRequest
{
    public int UserId { get; set; }
    public FlockInclude Include { get; set; }
    public string? Search { get; set; }
    public string? Name { get; set; }
    public DateTime? CreatedAfter { get; set; }
    public DateTime? CreatedBefore { get; set; }
}