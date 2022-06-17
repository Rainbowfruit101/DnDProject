namespace Services.Filtration.Utils;

public class OptionsFilter<TItem, TOptions>
{
    private IEnumerable<TItem> _enumerable;
    private readonly TOptions _options;
    
    public OptionsFilter(IEnumerable<TItem> enumerable, TOptions options)
    {
        _enumerable = enumerable;
        _options = options;
    }

    public OptionsFilter<TItem, TOptions> FilterBy<TOption>(Func<TOptions, TOption> optionSelector, Func<TItem, TOption, bool> predicate)
    {
        if (!_enumerable.Any())
            return this;
        
        var optionValue = optionSelector(_options);
        if (optionValue != null)
        {
            _enumerable = _enumerable.Where(i => predicate(i, optionValue));
        }
        
        return this;
    }

    public IEnumerable<TItem> Finish() => _enumerable;
}