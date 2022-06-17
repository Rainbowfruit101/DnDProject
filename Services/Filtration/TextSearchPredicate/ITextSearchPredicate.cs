namespace Services.Filtration.TextSearchPredicate;

public interface ITextSearchPredicate
{
    bool Run(string fieldValue, string searchedText);
    bool SubstringPredicate(string fieldValue, string searchedText, bool caseSensitive);
    bool ByWordsPredicate(string fieldValue, string searchedText, bool caseSensitive);
    bool ExactPredicate(string fieldValue, string searchedText, bool caseSensitive);
}