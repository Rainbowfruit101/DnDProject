using Database;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;

namespace Services.Crud;

public abstract class CrudServiceBase<TEntity> : ICrudService<TEntity>
    where TEntity : class, IIdentifiable, new()
{
    private readonly IRepository<TEntity> _repository;

    protected CrudServiceBase(IRepository<TEntity> repository)
    {
        _repository = repository;
    }

    public virtual async Task<TEntity?> CreateAsync(Func<Guid, TEntity?> entityProducer)
    {
        var id = Guid.NewGuid();
        var entity = entityProducer(id);
        if (entity == null)
            return null;
        
        var entityEntry = await _repository.GetDbSet().AddAsync(entity);
        entity = entityEntry.Entity;

        await _repository.SaveAsync();

        return entity;
    }

    public async Task<IEnumerable<TEntity>> ReadAllAsync()
    {
        return await _repository.GetQueryable().ToArrayAsync();
    }
    
    public virtual async Task<TEntity?> ReadAsync(Guid id)
    {
        return await _repository.GetQueryable().FirstOrDefaultAsync(e => e.Id == id);
    }

    public virtual async Task<TEntity?> UpdateAsync(TEntity source)
    {
        var updatedEntity = _repository.GetDbSet().Update(source).Entity;
        await _repository.SaveAsync();
        return updatedEntity;
    }

    public virtual async Task<TEntity?> DeleteAsync(Guid id)
    {
        var existingEntity = await ReadAsync(id);
        if (existingEntity == null)
            return null;
        
        _repository.GetDbSet().Remove(existingEntity);
        await _repository.SaveAsync();

        return existingEntity;
    }
}