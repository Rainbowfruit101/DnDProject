using Models.Interfaces;

namespace Models.Common;

public class SpellComponent : IIdentifiable, IHasName
{
    public Guid Id { get; init; }
    public string Name { get; }
}