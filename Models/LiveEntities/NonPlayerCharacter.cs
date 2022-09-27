using Models.Common;
using Models.Interfaces;

namespace Models.LiveEntities;

public class NonPlayerCharacter : ILiveEntity
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    public int Level { get; set; }
    public Ideology Ideology { get; init; }
    public int ArmorClass { get; init; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public List<Characteristic> Сharacteristics { get; init; }
    public string Background { get; init; }
    public LiveEntityClass PersonClass { get; init; }
    public LiveEntityRace PersonRace { get; init; }
    public List<Spell> Spells { get; init; }
    public string ImageSource { get; set; }
    public List<Status> Statuses { get; init; }

    public Backpack Backpack { get; init; }
    public double Relation { get; set; }
}