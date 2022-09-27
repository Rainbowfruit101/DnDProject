using Models.Enums;
using Models.Interfaces;

namespace Models.Items;

public class Property : IIdentifiable
{
    public Guid Id { get; set; }
    public string Title { get; init; }
    public string Description { get; init; }

    public PropertyType Type { get; init; }
    public List<Weapon> Weapons { get; init; }
}