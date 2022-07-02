using Models.Common;
using Models.LiveEntities;

namespace Services.Filtration.FilterOptions;

public class SpellFilterOptions
{
    public string? Name { get; init; }
    public School.Type? School { get; init; }
    public List<LiveEntityClass.Type>? AvailableClasses { get; init; }
    public int? Level { get; init; }
    public bool? UseConcentration { get; init; }
    public List<SpellComponent.Type>? AvailableComponents { get; init; }
}