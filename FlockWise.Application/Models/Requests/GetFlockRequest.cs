namespace FlockWise.Application.Models.Requests;

public class GetFlockRequest
{
    public FlockInclude Include { get; set; } = FlockInclude.None;
}