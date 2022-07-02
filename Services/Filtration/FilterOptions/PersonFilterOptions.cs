using Models.LiveEntities;

namespace Services.Filtration.FilterOptions;

public class PersonFilterOptions
{
    public string? Name { get; init; }
    public Ideology.Type? Ideology { get; init; }
    public int? Level { get; init; }
    public List<LiveEntityClass.Type>? PersonClasses { get; init; }
    public LiveEntityRace.Race? PersonRace { get; init; }
}