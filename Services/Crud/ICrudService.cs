using Models.Interfaces;

namespace Services.Crud;

public interface ICrudService<TEntity>
    where TEntity : IIdentifiable
{
    Task<TEntity?> CreateAsync(Func<Guid, TEntity> entityProducer);
    Task<IEnumerable<TEntity>> ReadAllAsync();
    Task<TEntity?> ReadAsync(Guid id);
    Task<TEntity?> UpdateAsync(TEntity source);
    Task<TEntity?> DeleteAsync(Guid id);
}