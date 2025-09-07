namespace FlockWise.Application.Models.Requests;

public class GetSheepRequest
{
    public Guid Id { get; set; }
    public SheepInclude Include { get; set; } = SheepInclude.None;
}