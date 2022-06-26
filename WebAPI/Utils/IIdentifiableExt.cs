using Models.Interfaces;

namespace WebAPI.Utils;

public static class IdentifiableExt
{
    public static TEntity AttachId<TEntity>(this TEntity identifiable, Guid id)
        where TEntity : IIdentifiable
    {
        identifiable.Id = id;
        return identifiable;
    }
}