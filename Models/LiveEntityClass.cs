namespace Models;

public class LiveEntityClass: ModelBase
{
    public enum ClassType
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

    public ClassType EClassType { get; init; }
    public string Name { get; init; }
}