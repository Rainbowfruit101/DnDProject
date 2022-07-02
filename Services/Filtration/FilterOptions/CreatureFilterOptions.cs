using Models.LiveEntities;

namespace Services.Filtration.FilterOptions;

public class CreatureFilterOptions
{
    public string? Name { get; init; }
    public Ideology.Type? Ideology { get; init; }
    public int? Level { get; init; }
    public LiveEntityClass.Type? PersonClass { get; init; }
    public LiveEntityRace.Race? PersonRace { get; init; }
}