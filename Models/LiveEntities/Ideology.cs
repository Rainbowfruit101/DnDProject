namespace Models.LiveEntities;

public class Ideology
{
    public enum Type
    {
        LawfulGood, 
        Good, 
        ChaoticGood, 
        Lawful, 
        TrulyNeutral, 
        Chaotic, 
        LawfulEvil, 
        Evil, 
        ChaoticEvil
    }
    public Guid Id { get; set; }
    public string Name { get; init; }

    public Type EType { get; init; }
}