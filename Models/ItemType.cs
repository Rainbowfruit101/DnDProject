namespace Models;

public class ItemType
{
    public enum Type
    {
        MagicRod, Armor, Wand, Potion, Ring, Weapon, Staff, Scroll, WondrousItem
    }

    public Type EType { get; }
    public string Name { get; }
}