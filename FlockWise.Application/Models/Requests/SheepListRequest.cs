namespace FlockWise.Application.Models.Requests;

public class SheepListRequest : BaseFilterRequest
{
    public int UserId { get; set; }
    public Guid? FlockId { get; set; }
    public string? Search { get; set; }
    public string? Breed { get; set; }
    public Sex? Sex { get; set; }
    public SheepStatus? Status { get; set; }
    public LifeStage? LifeStage { get; set; }
    public SheepInclude Include { get; set; } = SheepInclude.None;
}