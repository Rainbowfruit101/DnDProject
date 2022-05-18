using Models.Interfaces;

namespace Models.Items;

public class Weapon : IIdentifiable, IHasName, IHasCost
{
    public Guid Id { get; init; }
    public int Cost { get; }
    public string Name { get; }
    public int DiceCount { get; }
    public int DiceEdges { get; }
    public DamageType DamageType { get; }
    public double Weight { get; }
    public string Properties { get; }
}