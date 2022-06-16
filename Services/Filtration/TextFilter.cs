namespace Services.Filtration;

public class TextFilter<TItem>
{
    private IEnumerable<TItem> _enumerable;

    private readonly TextPredicates _textPredicates;
    
    public TextFilter(IEnumerable<TItem> enumerable)
    {
        _enumerable = enumerable;
        _textPredicates = new TextPredicates();
    }

    public TextFilter<TItem> SearchExact(string searchedText, Func<TItem, string> fieldSelector, 
        bool caseSensitive = false)
    {
        _enumerable = _enumerable.Where(i => 
            _textPredicates. ExactPredicate(fieldSelector(i), searchedText, caseSensitive)
        );
        return this;
    }

    public TextFilter<TItem> SearchSubstring(Func<TItem, string> fieldSelector, string searchedText,
        bool caseSensitive = false)
    {
        _enumerable = _enumerable.Where(i => 
            _textPredicates.SubstringPredicate(fieldSelector(i), searchedText, caseSensitive)
        );
        return this;
    }

    public TextFilter<TItem> SearchByWords(string searchedText, Func<TItem, string> fieldSelector,
        bool caseSensitive = false)
    {
        _enumerable = _enumerable.Where(i => 
            _textPredicates.ByWordsPredicate(fieldSelector(i), searchedText, caseSensitive)
        );
        return this;
    }

    public IEnumerable<TItem> Finish() => _enumerable;
}