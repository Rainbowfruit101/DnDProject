namespace Services.Filtration.FilterOptions;

public class Range<T>
    where T: IComparable<T>
{
    public bool HasMin { get; init; }
    public bool HasMax { get; init; }
    
    public T Min { get; init; }
    public T Max { get; init; }

    public bool InRange(T value)
    {
        //ignore if min or max not present
        var minBorder = !HasMin || value.CompareTo(Min) >= 0;
        var maxBorder = !HasMax || value.CompareTo(Max) <= 0;
        return minBorder && maxBorder;
    }
}