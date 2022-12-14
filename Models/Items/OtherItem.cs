using Models.Common;
using Models.Interfaces;

namespace Models.Items;

public class OtherItem: IIdentifiable, IHasName
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    
    public List<Backpack> Backpacks { get; init; }
}