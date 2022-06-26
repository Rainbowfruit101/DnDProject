namespace Models.Items;

public class Property
{
    public Guid Id { get; set; }
    public string Title { get; init; }
    public string Description { get; init; }
    public List<Weapon> Weapons { get; init; }
}