using Models.Interfaces;
using Models.LiveEntities;

namespace Models.Common;

public class Characteristic : IIdentifiable, IHasName
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    public int Value { get; set; }
    public int Modifier => (int) Math.Floor((Value - 10) / 2.0);
    
    public List<NonPlayerCharacter> NonPlayerCharacters { get; init; }
    public List<Person> Persons { get; init; }
    public List<Creature> Creatures { get; init; }
}