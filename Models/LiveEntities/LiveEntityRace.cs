using Models.Enums;
using Models.Interfaces;

namespace Models.LiveEntities;

public class LiveEntityRace : IIdentifiable, IHasName
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    public RaceType Type { get; init; }
}