using Models.Interfaces;

namespace Models.Items;

public class Weapon : IIdentifiable, IHasName, IHasCost
{
    public Guid Id { get; set; }
    public int Cost { get; init; }
    public string Name { get; init; }
    public DamageType DamageType { get; init; }
    public double Weight { get; init; }
    public List<Property> Properties { get; init; }
}