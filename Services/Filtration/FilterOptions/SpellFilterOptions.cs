using Models.Common;
using Models.Enums;
using Models.LiveEntities;

namespace Services.Filtration.FilterOptions;

public class SpellFilterOptions
{
    public string? Name { get; init; }
    public SchoolType? School { get; init; }
    public List<ClassType>? AvailableClasses { get; init; }
    public int? Level { get; init; }
    public bool? UseConcentration { get; init; }
    public List<ComponentType>? AvailableComponents { get; init; }
}