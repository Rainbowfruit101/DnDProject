using Database;
using Models.Items;
using Services.Filtration.FilterOptions;

namespace Services.Filtration.Impls;

public class ItemFilterService
{
    private readonly CommonDbContext _dbContext;
    private readonly TextPredicates _textPredicates;

    public ItemFilterService(CommonDbContext dbContext)
    {
        _dbContext = dbContext;
        _textPredicates = new TextPredicates();
    }

    public IEnumerable<Item> FilterItems(ItemFilterOptions filterOptions)
    {
        return new Filter<Item, ItemFilterOptions>(_dbContext.Items, filterOptions)
            .FilterBy(o => o.CostRange, 
                (item, range) => range.InRange(item.Cost))
            .FilterBy(o => o.Rarity, 
                (item, rarity) => item.Rarity == rarity)
            .FilterBy(o => o.Type, 
                (item, type) => item.Type == type)
            .FilterBy(o => o.LinkRequired, 
                (item, link) => item.LinkRequired == link)
            .FilterBy(o => o.Properties,
                (item, properties) => _textPredicates.ByWordsPredicate(item.Properties, properties, false))
            .Finish();
    }
}