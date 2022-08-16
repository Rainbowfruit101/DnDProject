using Models.Enums;
using Models.Items;

namespace Services.Filtration.FilterOptions;

public class WeaponFilterOptions
{
    public Range<int>? CostRange { get; init; }
    public string? Name { get; init; }
    public DamageEType? DamageType { get; init; }
    public List<PropertyType>? Properties { get; init; }
}