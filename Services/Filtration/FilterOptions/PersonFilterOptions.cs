using Models.Enums;
using Models.LiveEntities;

namespace Services.Filtration.FilterOptions;

public class PersonFilterOptions
{
    public string? Name { get; init; }
    public IdeologyType? Ideology { get; init; }
    public int? Level { get; init; }
    public List<ClassType>? PersonClasses { get; init; }
    public RaceType? PersonRace { get; init; }
}