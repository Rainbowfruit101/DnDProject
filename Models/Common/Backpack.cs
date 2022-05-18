using Models.Interfaces;
using Models.Items;

namespace Models.Common;

public class Backpack : IIdentifiable
{
    public Guid Id { get; init; }
    public List<Item> Items { get; }
    public List<string> OtherItems { get; }
}