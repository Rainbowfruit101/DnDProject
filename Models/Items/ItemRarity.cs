using Models.Interfaces;

namespace Models.Items;

public class ItemRarity : IIdentifiable, IHasName
{
    public enum Rarity
    {
        None,
        Common,
        Uncommon,
        Rare,
        VeryRare,
        Legendary,
        Artifact,
        Various
    }

    public Guid Id { get; init; }
    public string Name { get; }

    public Rarity ERarity { get; }
    public int Modifier { get; }
}