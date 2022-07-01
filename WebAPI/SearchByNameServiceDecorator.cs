using Database;
using Models.Interfaces;
using Services.Filtration;

namespace WebAPI;

public class SearchByNameServiceDecorator
{
    private readonly SearchByNameService _searchService;
    private readonly string _searchedValue;

    public SearchByNameServiceDecorator(SearchByNameService searchService, string searchedValue)
    {
        _searchService = searchService;
        _searchedValue = searchedValue;
    }
        
    public IEnumerable<TEntity> SearchEntities<TEntity>(Func<CommonDbContext, IEnumerable<TEntity>> collectionSelector)
        where TEntity : IHasName
    {
        return _searchService.SearchEntities(collectionSelector, _searchedValue);
    }
}