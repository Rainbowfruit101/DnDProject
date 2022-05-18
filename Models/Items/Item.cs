using Models.Interfaces;

namespace Models.Items;

public class Item : IIdentifiable, IHasName, IHasCost
{
    public Guid Id { get; init; }
    public string Name { get; }
    public int Cost { get; }
    public ItemType Type { get; }
    public ItemRarity Rarity { get; }
    public bool LinkRequired { get; }
    public string Properties { get; }
    public string ImageSource { get; }
}