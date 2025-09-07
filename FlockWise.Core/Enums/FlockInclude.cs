namespace FlockWise.Core.Enums;

[Flags]
public enum FlockInclude
{
    None = 0,
    Sheep = 1,
    Field = 2,
    FlockNotes = 4,
    
    SheepAndField = Sheep | Field,
    All = Sheep | Field | FlockNotes
}