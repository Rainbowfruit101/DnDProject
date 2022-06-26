using Database;
using Microsoft.EntityFrameworkCore;
using Models.Interfaces;

namespace Services.Crud;

public abstract class CrudServiceBase<TEntity> : ICrudService<TEntity>
    where TEntity : class, IIdentifiable, new()
{
    private readonly CommonDbContext _dbContext;

    public CrudServiceBase(CommonDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    protected abstract DbSet<TEntity> GetDbSet(CommonDbContext dbContext);

    private DbSet<TEntity> GetConcreteDbSet() => GetDbSet(_dbContext);

    public virtual TEntity? Create(Func<Guid, TEntity?> entityProducer)
    {
        var id = Guid.NewGuid();
        var entity = entityProducer(id);
        if (entity == null)
            return null;

        GetConcreteDbSet().Add(entity);
        _dbContext.SaveChanges();

        return entity;
    }

    public IEnumerable<TEntity> ReadAll()
    {
        return GetConcreteDbSet().ToArray();
    }


    public virtual TEntity? Read(Guid id)
    {
        return GetConcreteDbSet().FirstOrDefault(e => e.Id == id);
    }

    public virtual TEntity? Update(TEntity source)
    {
        var updatedEntity = GetConcreteDbSet().Update(source).Entity;
        _dbContext.SaveChanges();
        return updatedEntity;
    }

    public virtual TEntity? Delete(Guid id)
    {
        var existingEntity = Read(id);
        if (existingEntity == null)
            return null;

        GetConcreteDbSet().Remove(existingEntity);
        return existingEntity;
    }
}