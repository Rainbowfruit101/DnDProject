namespace Services.Filtration;

public class Filter<TItem, TOptions>
{
    private IEnumerable<TItem> _enumerable;
    private readonly TOptions _options;
    
    public Filter(IEnumerable<TItem> enumerable, TOptions options)
    {
        _enumerable = enumerable;
        _options = options;
    }

    public Filter<TItem, TOptions> FilterBy<TOption>(Func<TOptions, TOption> optionSelector, Func<TItem, TOption, bool> predicate)
    {
        var optionValue = optionSelector(_options);
        if (optionValue != null)
        {
            _enumerable = _enumerable.Where(i => predicate(i, optionValue));
        }
        
        return this;
    }

    public IEnumerable<TItem> Finish() => _enumerable;
}