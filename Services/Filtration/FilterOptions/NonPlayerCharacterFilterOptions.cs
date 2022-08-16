using Models.Enums;
using Models.LiveEntities;

namespace Services.Filtration.FilterOptions;

public class NonPlayerCharacterFilterOptions
{
    public string? Name { get; init; }
    public IdeologyType? Ideology { get; init; }
    public int? Level { get; init; }
    public ClassType? PersonClass { get; init; }
    public RaceType? PersonRace { get; init; }
}