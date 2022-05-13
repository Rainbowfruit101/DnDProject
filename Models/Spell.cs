namespace Models;

public class Spell
{
    public string Name { get; }
    public string School { get; }
    public LiveEntityClass Class { get; }
    public int Level { get; }
    public bool UseConcentration { get; }
    public string ConcentrationTime { get; }
    public int DiceCount { get; }
    public int DiceEdges { get; }
    public DamageType DamageType { get; }
    public List<SpellComponent> AvailableComponents { get; }
    public string Description { get; }
}