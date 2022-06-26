using Models.Interfaces;
using Models.Items;

namespace Models.Common;

public class School : IIdentifiable, IHasName
{
    public enum Type
    {
        Incarnation,
        Summoning,
        Illusion,
        Necromancy,
        Protection,
        Charm,
        Transformation,
        Divination
    }

    public Guid Id { get; set; }
    public string Name { get; init; }

    public Type EType { get; init; }
}
