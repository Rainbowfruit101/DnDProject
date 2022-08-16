using Models.Common;
using Models.Enums;
using Models.Interfaces;

namespace Models.LiveEntities;

public class LiveEntityClass : IIdentifiable, IHasName
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    public ClassType Type { get; init; }
    
    public List<Spell> Spells { get; init; }
    public List<Person> Persons { get; init; }
}