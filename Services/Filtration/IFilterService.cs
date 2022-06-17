namespace Services.Filtration;

public interface IFilterService<out TItem, in TFilterOptions>
{
    IEnumerable<TItem> Filter(TFilterOptions options);
}