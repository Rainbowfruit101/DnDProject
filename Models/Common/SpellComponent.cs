using Models.Enums;
using Models.Interfaces;

namespace Models.Common;

public class SpellComponent : IIdentifiable, IHasName
{
    public Guid Id { get; set; }
    public string Name { get; init; }

    public ComponentType Type { get; init; }
    public List<Spell> Spells { get; init; }
}