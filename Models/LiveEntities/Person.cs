using Models.Common;
using Models.Interfaces;

namespace Models.LiveEntities;

public class Person : ILiveEntity
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public int Level { get; init; }
    public string Ideology { get; init; }
    public int MaxHealth { get; init; }
    public int CurrentHealth { get; init; }
    public List<Characteristic> Сharacteristics { get; init; }
    public string Background { get; init; }
    public LiveEntityClass PersonClass { get; init; }
    public LiveEntityRace PersonRace { get; init; }
    public List<Spell> Spells { get; init; }
    public string ImageSource { get; init; }
    public List<Status> CreatureStatus { get; init; }

    public string PlayerName { get; init; }
    public Backpack Backpack { get; init; }
}