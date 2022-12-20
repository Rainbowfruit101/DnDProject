using Microsoft.EntityFrameworkCore;
using Models.Items;

namespace Database.Repositories;

public class ItemsRepository : IRepository<Item>
{
    public CommonDbContext DbContext { get; }

    public ItemsRepository(CommonDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public DbSet<Item> GetDbSet() => DbContext.Items;

    public IQueryable<Item> GetQueryable()
    {
        return DbContext.Items
            .Include(i => i.Backpacks)
            .Include(i => i.Rarity)
            .Include(i => i.Type);
    }
}