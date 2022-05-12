namespace Models;

public class Person
{
    public string Name { get; init; }
    public string PlayerName { get; init; }
    public int Level { get; init; }
    public string Ideology { get; init; }
    public int MaxHealth { get; init; }
    public int CurrentHealth { get; init; }
    public List<Characteristic> Сharacteristics { get; init; }
    public string Background { get; init; }
    public Backpack Backpack { get; init; }
    public PersonClass PersonClass { get; init;}
    public PersonRace PersonRace { get; init;}
    public List<Spell> Spells { get; init;}
}