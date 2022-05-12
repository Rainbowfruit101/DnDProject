namespace Models;

public class ItemRarity
{
    public enum Rarity
    {
        None, Common, Uncommon, Rare, VeryRare, Legendary, Artifact, Various
    }

    public Rarity ERarity { get; }
    public string Name { get; }
    public int Modifier { get; }
    
}