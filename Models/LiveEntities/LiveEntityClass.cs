using Models.Common;
using Models.Interfaces;

namespace Models.LiveEntities;

public class LiveEntityClass : IIdentifiable, IHasName
{
    public enum Type
    {
        Bard,
        Sorcerer,
        Warrior,
        Barbarian,
        Wizard,
        Druid,
        Monk,
        Paladin,
        Priest,
        Rogue,
        Tracker,
        Enchanter,
        Inventor
    }

    public Guid Id { get; set; }
    public string Name { get; init; }
    public Type EType { get; init; }
    
    public List<Spell> Spells { get; init; }
    public List<Person> Persons { get; init; }
}