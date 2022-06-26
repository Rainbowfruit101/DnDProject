using Models.Interfaces;

namespace Models.LiveEntities;

public class Status : IIdentifiable, IHasName
{
    public enum Type
    {
        Unconscious,
        Frightened,
        Exhausted,
        Invisible,
        Incapacitated,
        Deaf,
        Petrified,
        Entangled,
        Blinded,
        Poisoned,
        Enchanted,
        Stunned,
        Paralyzed,
        KnockedDown,
        Seized
    }

    public Guid Id { get; set; }
    public string Name { get; init; }
    public Type EType { get; init; }
    public string ImageSource { get; init; }
    public string Description { get; init; }
    
    public List<NonPlayerCharacter> NonPlayerCharacters { get; init; }
    public List<Person> Persons { get; init; }
    public List<Creature> Creatures { get; init; }
}