namespace Services.Filtration.FilterOptions;

public class Range<T>
    where  T: IComparable<T>
{
    public T? Min { get; init; }
    public T? Max { get; init; }

    public bool InRange(T value)
    {
        //ignore if min or max not present
        var minBorder = Min == null ? true : value.CompareTo(Min) >= 0;
        var maxBorder = Max == null ? true : value.CompareTo(Max) <= 0;
        return minBorder && maxBorder;
    }
}