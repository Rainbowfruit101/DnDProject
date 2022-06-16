using Models.Items;

namespace Services.Filtration.FilterOptions;

public class ItemFilterOptions
{
    public Range<int>? CostRange { get; init; }
    public ItemType? Type { get; init; }
    public ItemRarity? Rarity { get; init; }
    public bool? LinkRequired { get; init; }
    public string? Properties { get; init; }
}