namespace FlockWise.Application.Models.Requests;

public class GetFlockRequest
{
    public Guid Id { get; set; }
    public FlockInclude Include { get; set; } = FlockInclude.None;
}