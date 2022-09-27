using Models.Enums;
using Models.Interfaces;

namespace Models.LiveEntities;

public class Ideology : IIdentifiable, IHasName
{
    public Guid Id { get; set; }
    public string Name { get; init; }

    public IdeologyType Type { get; init; }
}