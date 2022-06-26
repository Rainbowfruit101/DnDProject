using Models.Common;
using Models.Interfaces;

namespace Models.Items;

public class Item : IIdentifiable, IHasName, IHasCost
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    public int Cost { get; init; }
    public ItemType Type { get; init; }
    public ItemRarity Rarity { get; init; }
    public bool LinkRequired { get; init; }
    public string Properties { get; init; }
    public string ImageSource { get; init; }
    
    public List<Backpack> Backpacks { get; init; }
}