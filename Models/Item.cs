namespace Models;

public class Item : ItemBase  
{
    public ItemType Type { get; } 
    public ItemRarity Rarity { get; }
    public bool LinkRequired { get; } 
    public string Properties { get; }
    public string ImageSource { get; }
}