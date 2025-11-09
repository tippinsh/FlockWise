namespace FlockWise.Core.Enums;

[Flags]
public enum SheepInclude
{
    None = 0,
    Flock = 1,
    BirthRecords = 2,
    WeightHistory = 4,
    All = Flock | BirthRecords | WeightHistory
}