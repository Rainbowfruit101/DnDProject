using Models.Interfaces;

namespace Models.Items;

public class DamageType : IIdentifiable
{
    public Guid Id { get; init; }

    public enum Type
    {
        Crushing, Stabbing, Slashing, Fire, Ice
    }

    public Type EType { get; }
    public string Name { get; }
}