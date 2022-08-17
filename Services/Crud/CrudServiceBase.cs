using Database;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;

namespace Services.Crud;

public abstract class CrudServiceBase<TEntity> : ICrudService<TEntity>
    where TEntity : class, IIdentifiable, new()
{
    private readonly CommonDbContext _dbContext;

    protected CrudServiceBase(CommonDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected abstract DbSet<TEntity> GetDbSet(CommonDbContext dbContext);
    
    private DbSet<TEntity> GetConcreteDbSet() => GetDbSet(_dbContext);

    public virtual async Task<TEntity?> CreateAsync(Func<Guid, TEntity?> entityProducer)
    {
        var id = Guid.NewGuid();
        var entity = entityProducer(id);
        if (entity == null)
            return null;

        var entityEntry = await GetConcreteDbSet().AddAsync(entity);
        entity = entityEntry.Entity;
        
        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<IEnumerable<TEntity>> ReadAllAsync()
    {
        return await GetConcreteDbSet().ToArrayAsync();
    }
    
    public virtual async Task<TEntity?> ReadAsync(Guid id)
    {
        return await GetConcreteDbSet().FirstOrDefaultAsync(e => e.Id == id);
    }

    public virtual async Task<TEntity?> UpdateAsync(TEntity source)
    {
        var updatedEntity = GetConcreteDbSet().Update(source).Entity;
        await _dbContext.SaveChangesAsync();
        return updatedEntity;
    }

    public virtual async Task<TEntity?> DeleteAsync(Guid id)
    {
        var existingEntity = await ReadAsync(id);
        if (existingEntity == null)
            return null;
        
        GetConcreteDbSet().Remove(existingEntity);
        await _dbContext.SaveChangesAsync();
        
        return existingEntity;
    }
}