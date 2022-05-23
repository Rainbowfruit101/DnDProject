using Models.Interfaces;

namespace Models.Items;

public class OtherItem: IIdentifiable, IHasName
{
    public Guid Id { get; init; }
    public string Name { get; init; }
}