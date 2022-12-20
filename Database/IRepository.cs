using Microsoft.EntityFrameworkCore;

namespace Database;

public interface IRepository<TEntity> 
    where TEntity : class
{
    CommonDbContext DbContext { get; }
    DbSet<TEntity> GetDbSet();
    IQueryable<TEntity> GetQueryable();
}