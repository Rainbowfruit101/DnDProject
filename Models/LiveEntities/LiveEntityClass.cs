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

    public Guid Id { get; init; }
    public string Name { get; init; }
    public Type EType { get; init; }
}