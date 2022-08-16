using Models.Enums;
using Models.Interfaces;
using Models.Items;

namespace Models.Common;

public class School : IIdentifiable, IHasName
{
    public Guid Id { get; set; }
    public string Name { get; init; }

    public SchoolType Type { get; init; }
}