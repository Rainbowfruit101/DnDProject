using Models.Enums;
using Models.Interfaces;

namespace Models.Items;

public class ItemRarity : IIdentifiable, IHasName
{
    public Guid Id { get; set; }
    public string Name { get; init; }

    public RarityType Type { get; init; }
    public int Modifier { get; init; }
}