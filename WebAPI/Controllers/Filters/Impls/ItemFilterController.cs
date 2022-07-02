using Models.Items;
using Services.Filtration;
using Services.Filtration.FilterOptions;

namespace WebAPI.Controllers.Filters.Impls;

public class ItemFilterController : FilterControllerBase<Item, ItemFilterOptions>
{
    public ItemFilterController(IFilterService<Item, ItemFilterOptions> entityFilterService) : base(entityFilterService)
    {
    }

    protected override ItemFilterOptions GetFilterOptions()
    {
        var minCost = GetQueryInt("minCost");
        var maxCost = GetQueryInt("maxCost");

        var optionNames = new ItemFilterOptions();
        var options = new ItemFilterOptions()
        {
            Name = GetQueryString(nameof(optionNames.Name)),
            Properties = GetQueryString(nameof(optionNames.Properties)),
            Rarity = GetQueryEnum<ItemRarity.Rarity>(nameof(optionNames.Rarity)),
            Type = GetQueryEnum<ItemType.Type>(nameof(optionNames.Type)),
            CostRange = new Range<int>()
            {
                HasMin = minCost.HasValue,
                HasMax = maxCost.HasValue,
                Min = minCost ?? 0,
                Max = maxCost ?? 0
            },
            LinkRequired = GetQueryBool(nameof(optionNames.LinkRequired))
        };
        return options;
    }
}