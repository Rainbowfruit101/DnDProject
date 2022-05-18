using Models.Interfaces;

namespace Models.Common;

public class Characteristic : IIdentifiable
{
    public Guid Id { get; init; }
    public string Name { get; }
    public int Value { get; set; }
    public int Modifier => (int) Math.Floor((Value - 10) / 2.0);
}