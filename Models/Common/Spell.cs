using Models.Interfaces;
using Models.Items;
using Models.LiveEntities;

namespace Models.Common;

public class Spell : IIdentifiable, IHasName
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public School School { get; init; }
    public List<LiveEntityClass> AvailableClasses { get; init; }
    public int Level { get; init; }
    public bool UseConcentration { get; init; }
    public string ConcentrationTime { get; init; }
    public int DiceCount { get; init; }
    public int DiceEdges { get; init; }
    public DamageType DamageType { get; init; }
    public List<SpellComponent> AvailableComponents { get; init; }
    public string Description { get; init; }
}