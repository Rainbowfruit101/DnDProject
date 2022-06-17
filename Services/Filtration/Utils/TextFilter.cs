using Services.Filtration.TextSearchPredicate;

namespace Services.Filtration.Utils;

public class TextFilter<TItem>
{
    private IEnumerable<TItem> _enumerable;
    private readonly ITextSearchPredicate _textSearchPredicate;

    public TextFilter(IEnumerable<TItem> enumerable, ITextSearchPredicate textSearchPredicate)
    {
        _enumerable = enumerable;
        _textSearchPredicate = textSearchPredicate;
    }

    public TextFilter<TItem> SearchExact(Func<TItem, string> fieldSelector, string searchedText, 
        bool caseSensitive = false)
    {
        _enumerable = _enumerable.Where(i => 
            _textSearchPredicate.ExactPredicate(fieldSelector(i), searchedText, caseSensitive)
        );
        return this;
    }

    public TextFilter<TItem> SearchSubstring(Func<TItem, string> fieldSelector, string searchedText,
        bool caseSensitive = false)
    {
        _enumerable = _enumerable.Where(i => 
            _textSearchPredicate.SubstringPredicate(fieldSelector(i), searchedText, caseSensitive)
        );
        return this;
    }

    public TextFilter<TItem> SearchByWords(string searchedText, Func<TItem, string> fieldSelector,
        bool caseSensitive = false)
    {
        _enumerable = _enumerable.Where(i => 
            _textSearchPredicate.ByWordsPredicate(fieldSelector(i), searchedText, caseSensitive)
        );
        return this;
    }

    public IEnumerable<TItem> Finish() => _enumerable;
}