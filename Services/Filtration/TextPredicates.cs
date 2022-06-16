namespace Services.Filtration;

public class TextPredicates
{
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
    
    public bool ExactPredicate(string fieldValue, string searchedText, bool caseSensitive)
    {
        (fieldValue, searchedText) = PrepareCase(fieldValue, searchedText, caseSensitive);

        return fieldValue == searchedText;
    }
    
    private (string, string) PrepareCase(string field, string searchedText, bool caseSensitive)
    {
        return caseSensitive ? (field, searchedText) : (field.ToLower(), searchedText.ToLower());
    }
}