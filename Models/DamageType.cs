namespace Models;

public class DamageType
{
    public enum Type
    {
        Crushing, Stabbing, Slashing, Fire, Ice
    }

    public Type EType { get; }
    public string Name { get; }
}