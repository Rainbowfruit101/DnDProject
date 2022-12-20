using Microsoft.EntityFrameworkCore;
using Models.Common;

namespace Database.Repositories;

public class SpellsRepository : IRepository<Spell>
{
    public CommonDbContext DbContext { get; }

    public SpellsRepository(CommonDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public DbSet<Spell> GetDbSet() => DbContext.Spells;

    public IQueryable<Spell> GetQueryable()
    {
        return DbContext.Spells
            .Include(s => s.AvailableClasses)
            .Include(s => s.AvailableComponents)
            .Include(s => s.School);
    }
}