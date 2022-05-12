namespace Models;

public class Weapon : ItemBase
{
    public int DiceCount { get; }
    public int DiceEdges { get; }
    public DamageType DamageType { get; }
    public double Weight { get; }
    public string Properties { get; }
}