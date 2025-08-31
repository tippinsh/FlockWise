namespace FlockWise.Core.Events.Lambing;

public class LambBorn(Guid lambId, Guid damId, DateTimeOffset birthDate, Sex sex, Weight birthWeight)
    : DomainEvent
{
    public Guid LambId { get; set; } = lambId;
    public Guid EweId { get; set; } = damId;
    public DateTimeOffset BirthDate { get; set; } = birthDate;
    public Sex Sex { get; set; } = sex;
    public Weight BirthWeight { get; set; } = birthWeight;
}