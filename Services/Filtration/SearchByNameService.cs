using Models.Interfaces;

namespace Services.Filtration;

public class SearchByNameService
{
    private readonly TextPredicates _textPredicates;

    public SearchByNameService()
    {
        _textPredicates = new TextPredicates();
    }
    public IEnumerable<IHasName> SearchEntities(IEnumerable<IHasName> dbSet, string searchedValue)
    {
        return dbSet.Where(namedEntity => _textPredicates.SubstringPredicate(namedEntity.Name, searchedValue, false));
    }
}