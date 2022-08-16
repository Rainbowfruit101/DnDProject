using Database;
using Models.Items;
using Services.Filtration.FilterOptions;
using Services.Filtration.TextSearchPredicate;
using Services.Filtration.TextSearchPredicate.Impls;
using Services.Filtration.Utils;

namespace Services.Filtration.Impls;

public class ItemFilterService : IFilterService<Item, ItemFilterOptions>
{
    private readonly CommonDbContext _dbContext;
    private readonly ITextSearchPredicate _textSearchPredicate;

    public ItemFilterService(CommonDbContext dbContext, ITextSearchPredicate textSearchPredicate)
    {
        _dbContext = dbContext;
        _textSearchPredicate = textSearchPredicate;
    }

    public IEnumerable<Item> Filter(ItemFilterOptions filterOptions)
    {
        return new OptionsFilter<Item, ItemFilterOptions>(_dbContext.Items, filterOptions)
            .FilterBy(o => o.CostRange,
                (item, range) => range.InRange(item.Cost))
            .FilterBy(o => o.Rarity,
                (item, rarity) => item.Rarity.Type == rarity)
            .FilterBy(o => o.Type,
                (item, type) => item.Type.Type == type)
            .FilterBy(o => o.LinkRequired,
                (item, link) => item.LinkRequired == link)
            .FilterBy(o => o.Properties,
                (item, properties) => _textSearchPredicate.Run(item.Properties, properties))
            .FilterBy(o => o.Name,
                (item, name) => _textSearchPredicate.Run(item.Name, name))
            .Finish();
    }
}