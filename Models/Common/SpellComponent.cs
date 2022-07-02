using Models.Interfaces;

namespace Models.Common;

public class SpellComponent : IIdentifiable, IHasName
{
    public enum Type
    {
        Verbal, 
        Somatic, 
        Material
    }
    public Guid Id { get; set; }
    public string Name { get; init; }

    public Type EType { get; init; }
    public List<Spell> Spells { get; init; }
}