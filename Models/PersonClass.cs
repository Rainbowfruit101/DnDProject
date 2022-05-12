namespace Models;

public class PersonClass
{
    public enum ClassType
    {
        Bard, Sorcerer, Warrior, Barbarian, Wizard, Druid, Monk, Paladin, Priest, Rogue, Tracker, Enchanter, Inventor
    }

    public ClassType EClassType { get; }
    public string Name { get; }
}