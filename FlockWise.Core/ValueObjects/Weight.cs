namespace FlockWise.Core.ValueObjects;

public class Weight : IEquatable<Weight>
{
    public double Kilograms { get; }
    
    public Weight(double kilograms)
    {
        if (kilograms <= 0) throw new ArgumentException("Weight must be positive");
        Kilograms = kilograms;
    }
    
    public bool Equals(Weight? other)
    {
        if (other is null) return false;
        return Kilograms == other.Kilograms;
    }

    public override bool Equals(object? obj) => Equals(obj as Weight);

    public override int GetHashCode() => Kilograms.GetHashCode();

    public override string ToString() => $"{Kilograms} kg";
}