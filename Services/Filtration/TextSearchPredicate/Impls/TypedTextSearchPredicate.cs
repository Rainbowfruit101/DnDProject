namespace Services.Filtration.TextSearchPredicate.Impls;

public class TypedTextSearchPredicate : ITextSearchPredicate
{
    public enum Type
    {
        Exact,
        Substring,
        ByWords
    }
    
    private readonly Func<string, string, bool, bool> _textPredicate;
    private readonly bool _caseSensitive;

    public TypedTextSearchPredicate(Type type, bool caseSensitive)
    {
        _caseSensitive = caseSensitive;
        
        _textPredicate = type switch
        {
            Type.Exact => ExactPredicate,
            Type.Substring => SubstringPredicate,
            Type.ByWords => ByWordsPredicate,
            _ => throw new ArgumentOutOfRangeException($"Invalid type {type}.")
        };
    }
    
    public bool Run(string fieldValue, string searchedText)
    {
        return _textPredicate.Invoke(fieldValue, searchedText, _caseSensitive);
    }

    public bool ExactPredicate(string fieldValue, string searchedText, bool caseSensitive)
    {
        (fieldValue, searchedText) = PrepareCase(fieldValue, searchedText, caseSensitive);
        
        return fieldValue == searchedText;
    }

    public bool SubstringPredicate(string fieldValue, string searchedText, bool caseSensitive)
    {
        (fieldValue, searchedText) = PrepareCase(fieldValue, searchedText, caseSensitive);

        return fieldValue.Contains(searchedText);
    }

    public bool ByWordsPredicate(string fieldValue, string searchedText, bool caseSensitive)
    {
        (fieldValue, searchedText) = PrepareCase(fieldValue, searchedText, caseSensitive);

        var separators = new[] {" ", "-", ".", ",", ";", ":", "!", "?"};
        var splitOptions = StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries;
        
        var fieldWords = fieldValue.Split(separators, splitOptions);
        var searchedTextWords = searchedText.Split(' ', splitOptions);
        
        return searchedTextWords.All(stw => fieldWords.Contains(stw));
    }

    private (string, string) PrepareCase(string field, string searchedText, bool caseSensitive)
    {
        return caseSensitive ? (field, searchedText) : (field.ToLower(), searchedText.ToLower());
    }
}