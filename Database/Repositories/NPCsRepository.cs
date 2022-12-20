using Microsoft.EntityFrameworkCore;
using Models.LiveEntities;

namespace Database.Repositories;

public class NPCsRepository : IRepository<NonPlayerCharacter>
{
    public CommonDbContext DbContext { get; }

    public NPCsRepository(CommonDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public DbSet<NonPlayerCharacter> GetDbSet() => DbContext.NonPlayerCharacters;

    public IQueryable<NonPlayerCharacter> GetQueryable()
    {
        return DbContext.NonPlayerCharacters
            .Include(npc => npc.Backpack)
            .Include(npc => npc.Ideology)
            .Include(npc => npc.Spells)
            .Include(npc => npc.Statuses)
            .Include(npc => npc.Сharacteristics)
            .Include(npc => npc.PersonClass)
            .Include(npc => npc.PersonRace);
    }
}