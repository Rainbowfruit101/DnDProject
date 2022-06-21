using Models.LiveEntities;

namespace Services.Filtration.FilterOptions;

public class CreatureFilterOptions
{
    public string? Name { get; init; }
    public Ideology? Ideology { get; init; }
    public int? Level { get; init; }
    public LiveEntityClass? PersonClass { get; init; }
    public LiveEntityRace? PersonRace { get; init; }
}