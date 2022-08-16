using Models.Enums;
using Models.Interfaces;

namespace Models.Items;

public class ItemType : IIdentifiable, IHasName
{
    public Guid Id { get; set; }
    public string Name { get; init; }

    public ItemEType Type { get; init; }
}