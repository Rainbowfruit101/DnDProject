namespace Models;

public class PersonRace
{
    public enum Race
    {
        Human, Orc, Elf, HalfHuman
    }

    public Race ERace { get; }
    public string Name { get; }
}