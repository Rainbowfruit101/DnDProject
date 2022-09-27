using Models.Common;
using Models.Enums;
using Models.Interfaces;

namespace Models.Items;

public class DamageType : IIdentifiable, IHasName
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    public string Description { get; init; }
    
    public DamageEType Type { get; init; }
    
}