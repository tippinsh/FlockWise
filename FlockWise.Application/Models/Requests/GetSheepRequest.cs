namespace FlockWise.Application.Models.Requests;

public class GetSheepRequest
{
    public SheepInclude Include { get; set; } = SheepInclude.None;
}