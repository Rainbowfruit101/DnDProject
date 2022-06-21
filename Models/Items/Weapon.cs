using Models.Interfaces;

namespace Models.Items;

public class Weapon : IIdentifiable, IHasName, IHasCost
{
    public Guid Id { get; init; }
    public int Cost { get; init; }
    public string Name { get; init; }
    public int DiceCount { get; init; }
    public int DiceEdges { get; init; }
    public DamageType DamageType { get; init; }
    public double Weight { get; init; }
    public List<Property> Properties { get; init; }
}