using Models.Interfaces;

namespace Services.Crud;

public interface ICrudService<TEntity>
    where TEntity : IIdentifiable
{
    TEntity? Create(Func<Guid, TEntity> entityProducer);
    IEnumerable<TEntity> ReadAll();
    TEntity? Read(Guid id);
    TEntity? Update(TEntity source);
    TEntity? Delete(Guid id);
}
