using Microsoft.EntityFrameworkCore;
using Models.Interfaces;

namespace WebAPI;

public static class DbSetExt
{
    public static void RemoveAll<TEntity>(this DbSet<TEntity> dbSet)
        where TEntity :  class, IIdentifiable, new()
    {
        foreach (var id in dbSet.Select(o => o.Id))
        {
            var entity = new TEntity { Id = id };
            dbSet.Attach(entity);
            dbSet.Remove(entity);
        }
    }
}