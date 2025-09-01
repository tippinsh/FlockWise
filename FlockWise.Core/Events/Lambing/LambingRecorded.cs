namespace FlockWise.Core.Events.Lambing;

public class LambingRecorded
{
    public Guid Id { get; set; }
    public Guid EweId { get; set; }
    public Guid TupId { get; set; }
    public DateTimeOffset LambingDate { get; set; }
    public int NumberBorn { get; set; }
    public int NumberAlive { get; set; }
    public AssistanceType? AssistanceType { get; set; }
}