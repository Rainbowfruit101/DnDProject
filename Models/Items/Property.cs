namespace Models.Items;

public class Property
{
    public enum Type
    {
        Universal, 
        TwoHanded, 
        Longrange
    }
    public Guid Id { get; set; }
    public string Title { get; init; }
    public string Description { get; init; }

    public Type EType { get; init; }
    public List<Weapon> Weapons { get; init; }
}