namespace Models.Items;

public class Property
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    
    public List<Weapon> Weapons { get; init; }
}