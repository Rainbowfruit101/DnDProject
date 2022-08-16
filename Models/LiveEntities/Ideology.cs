using Models.Enums;

namespace Models.LiveEntities;

public class Ideology
{
    public Guid Id { get; set; }
    public string Name { get; init; }

    public IdeologyType Type { get; init; }
}