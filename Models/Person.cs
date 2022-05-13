namespace Models;

public class Person : LiveEntity
{
    public string PlayerName { get; init; }
    public Backpack Backpack { get; init; }
}