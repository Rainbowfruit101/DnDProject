using Models.Common;
using Models.Interfaces;

namespace Models.LiveEntities;

public class Person : ILiveEntity
{
    private readonly List<LiveEntityClass> _multiClass;
    
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public Ideology Ideology { get; set; }
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public List<Characteristic> Сharacteristics { get; init; }
    public string Background { get; init; }
    public LiveEntityClass PersonClass { get; set; }
    public LiveEntityRace PersonRace { get; init; }
    public List<Spell> Spells { get; init; }
    public string ImageSource { get; set; }
    public List<Status> Statuses { get; init; }

    public string PlayerName { get; init; }
    public Backpack Backpack { get; init; }

    public IReadOnlyList<LiveEntityClass> MultiClasses
    {
        get => _multiClass;
        init => _multiClass = value.ToList();
    }
    public LiveEntityClass[] AllClasses => _multiClass.Concat(new[] { PersonClass }).ToArray();

    public Person()
    {
        _multiClass = new List<LiveEntityClass>();
    }

    public void AddMultiClass(LiveEntityClass liveEntityClass)
    {
        if(liveEntityClass.EType == PersonClass.EType)
            return;
        
        if(_multiClass.Any(mc => mc.EType == liveEntityClass.EType))
            return;

        _multiClass.Add(liveEntityClass);
    }

    public void RemoveMultiClass(LiveEntityClass.Type classType)
    {
        var liveEntityClass = _multiClass.FirstOrDefault(mc => mc.EType == classType);
        if(liveEntityClass == null)
            return;

        _multiClass.Remove(liveEntityClass);
    }
}