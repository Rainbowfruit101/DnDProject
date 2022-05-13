namespace Models;

public class LiveEntityRace
{
    public enum Race
    {
        Aarakocra,
        Aasimar,
        Bugbear,
        Vedalken,
        Verdan,
        SimicHybrid,
        Gith,
        Gnome,
        Goblin,
        Goliath,
        Grung,
        Dwarf,
        Genasi,
        Dragonborn,
        Kalashtar,
        Kenku,
        Centaur,
        Kobold,
        Warforged,
        Leonin,
        Locathah,
        Loxodon,
        Lizardfolk,
        Minotaur,
        Orc,
        HalfOrc,
        Halfling,
        HalfElf,
        Satyr,
        Owlin,
        Tabaxi,
        Tiefling,
        Tortle,
        Triton,
        Firbolg,
        Fairy,
        Harengon,
        Hobgoblin,
        Changeling,
        Human,
        Shifter,
        Elf,
        YuanTiPureblood
    }

    public Race ERace { get; }
    public string Name { get; }
}