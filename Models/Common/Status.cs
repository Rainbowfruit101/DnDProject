using Models.Interfaces;

namespace Models.Common;

public class Status : IIdentifiable, IHasName
{
    public Guid Id { get; init; }
    public string Name { get; }
    public string ImageSource { get; }
    public string Description { get; }
}