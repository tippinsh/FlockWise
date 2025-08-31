namespace FlockWise.Core.Events.Sheep;

public class SheepBorn(
    Guid id,
    string breed,
    string pedigree,
    DateTimeOffset dateOfBirth,
    Guid fatherId,
    Guid motherId,
    double weightBornKgs,
    Sex sex)
{
    public Guid Id { get; set; } = id;
    public string Breed { get; set; } = breed;
    public string Pedigree { get; set; } = pedigree;
    public DateTimeOffset DateOfBirthUtc{ get; set; } = dateOfBirth;
    public Guid FatherId { get; set; } = fatherId;
    public Guid MotherId { get; set; } = motherId;
    public double WeightBornKgs { get; set; } = weightBornKgs;
    public Sex Sex { get; set; } = sex;
}