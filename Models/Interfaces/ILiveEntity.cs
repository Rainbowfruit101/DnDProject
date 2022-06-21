using Models.Common;
using Models.LiveEntities;

namespace Models.Interfaces;

public interface ILiveEntity : IIdentifiable, IHasName
{
    public int Level { get; }
    public Ideology Ideology { get; }
    public int MaxHealth { get; }
    public int CurrentHealth { get; }
    public List<Characteristic> Сharacteristics { get; }
    public string Background { get; }
    public LiveEntityClass PersonClass { get; }
    public LiveEntityRace PersonRace { get; }
    public List<Spell> Spells { get; }
    public string ImageSource { get; }
    public List<Status> Statuses { get; }
}