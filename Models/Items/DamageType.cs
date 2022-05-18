using Models.Interfaces;

namespace Models.Items;

public class DamageType : IIdentifiable, IHasName
{
    public enum Type
    {
        Crushing,
        Sound,
        Radiation,
        Acidic,
        Stabbing,
        Necrotic,
        Fiery,
        Psychic,
        Chopping,
        Forceful,
        Cold,
        Electric,
        Poisonous
    }

    public Guid Id { get; init; }
    public string Name { get; init; }

    public Type EType { get; init; }
}