namespace FlockWise.Core.Enums;

public enum SheepInclude
{
    None = 0,
    Flock = 1,
    BirthRecords = 2,
    WeightHistory = 4,
    All = Flock | BirthRecords | WeightHistory
}