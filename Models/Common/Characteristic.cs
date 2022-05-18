using Models.Interfaces;

namespace Models.Common;

public class Characteristic : IIdentifiable, IHasName
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public int Value { get; set; }
    public int Modifier => (int) Math.Floor((Value - 10) / 2.0);
}