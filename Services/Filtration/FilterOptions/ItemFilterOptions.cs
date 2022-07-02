﻿using Models.Items;

namespace Services.Filtration.FilterOptions;

public class ItemFilterOptions
{
    public string? Name { get; init; }
    public Range<int>? CostRange { get; init; }
    public ItemType.Type? Type { get; init; }
    public ItemRarity.Rarity? Rarity { get; init; }
    public bool? LinkRequired { get; init; }
    public string? Properties { get; init; }
}