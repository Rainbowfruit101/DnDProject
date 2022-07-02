using Models.Items;

namespace Services.Filtration.FilterOptions;

public class WeaponFilterOptions
{
    public Range<int>? CostRange { get; init; }
    public string? Name { get; init; }
    public DamageType.Type? DamageType { get; init; }
    public List<Property.Type>? Properties { get; init; }
}