using Microsoft.EntityFrameworkCore;
using Models.LiveEntities;

namespace Database.Repositories;

public class CreaturesRepository : IRepository<Creature>
{
    public CommonDbContext DbContext { get; }

    public CreaturesRepository(CommonDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public DbSet<Creature> GetDbSet() => DbContext.Creatures;

    public IQueryable<Creature> GetQueryable()
    {
        return DbContext.Creatures
            .Include(c => c.PersonClass)
            .Include(c => c.PersonRace)
            .Include(c => c.Ideology)
            .Include(c=>c.Spells)
            .Include(c=> c.Statuses)
            .Include(c=> c.Сharacteristics);
    }
}