using Microsoft.EntityFrameworkCore;
using Models.Items;

namespace Database.Repositories;

public class WeaponsRepository : IRepository<Weapon>
{
    public CommonDbContext DbContext { get; }

    public WeaponsRepository(CommonDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public DbSet<Weapon> GetDbSet() => DbContext.Weapons;

    public IQueryable<Weapon> GetQueryable()
    {
        return DbContext.Weapons
            .Include(w => w.Properties)
            .Include(w => w.DamageType);
    }
}