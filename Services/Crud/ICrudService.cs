namespace Services.Crud;

public interface ICrudService<TEntity>
{
    TEntity? Create(Func<Guid, TEntity> entityProducer);
    TEntity? Read(Guid id);
    TEntity? Update(TEntity source);
    TEntity? Delete(Guid id);
}