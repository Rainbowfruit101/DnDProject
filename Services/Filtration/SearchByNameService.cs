using Database;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;
using Models.LiveEntities;
using Services.Filtration.FilterOptions;
using Services.Filtration.TextSearchPredicate;
using Services.Filtration.TextSearchPredicate.Impls;
using Services.Filtration.Utils;

namespace Services.Filtration;

public class SearchByNameService
{
    private readonly CommonDbContext _dbContext;
    private readonly ITextSearchPredicate _textSearchPredicate;

    public SearchByNameService(CommonDbContext dbContext, ITextSearchPredicate textSearchPredicate)
    {
        _dbContext = dbContext;
        _textSearchPredicate = textSearchPredicate;
    }
    public IEnumerable<TEntity> SearchEntities<TEntity>(Func<CommonDbContext, IEnumerable<TEntity>> collectionSelector, string searchedValue)
        where TEntity : IHasName
    {
        var collection = collectionSelector?.Invoke(_dbContext);
        return collection.Where(namedEntity => _textSearchPredicate.Run(namedEntity.Name, searchedValue));
    }
}