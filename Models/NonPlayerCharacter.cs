namespace Models;

public class NonPlayerCharacter : LiveEntity
{
    public Backpack Backpack { get; init; }
    public double Relation { get; set; }
}