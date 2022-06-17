using Models.Interfaces;
using Services.Filtration.TextSearchPredicate;
using Services.Filtration.TextSearchPredicate.Impls;

namespace Services.Filtration;

public class SearchByNameService
{
    private readonly ITextSearchPredicate _textSearchPredicate;

    public SearchByNameService(ITextSearchPredicate textSearchPredicate)
    {
        _textSearchPredicate = textSearchPredicate;
    }
    public IEnumerable<IHasName> SearchEntities(IEnumerable<IHasName> dbSet, string searchedValue)
    {
        return dbSet.Where(namedEntity => _textSearchPredicate.Run(namedEntity.Name, searchedValue));
    }
}