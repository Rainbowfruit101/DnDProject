using Models.Interfaces;

namespace Services;

public class SearchByNameServiceDecorator
{
    private readonly SearchByNameService _searchService;
    private readonly string _searchedValue;

    public SearchByNameServiceDecorator(SearchByNameService searchService, string searchedValue)
    {
        _searchService = searchService;
        _searchedValue = searchedValue;
    }
        
    public IEnumerable<IHasName> SearchEntities(IEnumerable<IHasName> dbSet)
    {
        return _searchService.SearchEntities(dbSet, _searchedValue);
    }
}