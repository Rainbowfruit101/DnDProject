using Models.Interfaces;

namespace Models.Items;

public class DamageType : IIdentifiable, IHasName
{
    public enum Type
    {
        Crushing,
        Stabbing,
        Slashing,
        Fire,
        Ice
    }

    public Guid Id { get; init; }
    public string Name { get; }

    public Type EType { get; }
}