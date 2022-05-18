using Models.Interfaces;

namespace Models.Items;

public class ItemType : IIdentifiable, IHasName
{
    public enum Type
    {
        MagicRod,
        Armor,
        Wand,
        Potion,
        Ring,
        Weapon,
        Staff,
        Scroll,
        WondrousItem
    }

    public Guid Id { get; init; }
    public string Name { get; init; }

    public Type EType { get; init; }
}