using Microsoft.EntityFrameworkCore;
using Models.LiveEntities;

namespace Database.Repositories;

public class PersonsRepository : IRepository<Person>
{
    public CommonDbContext DbContext { get; }

    public PersonsRepository(CommonDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public DbSet<Person> GetDbSet() => DbContext.Persons;

    public IQueryable<Person> GetQueryable()
    {
        return DbContext.Persons
            .Include(p => p.Backpack)
            .Include(p => p.Ideology)
            .Include(p => p.Spells)
            .Include(p => p.Statuses)
            .Include(p => p.Сharacteristics)
            .Include(p => p.AllClasses) //TODO: вот тут вапросек, пока непонятно, как будет работать
            .Include(p => p.PersonClass)
            .Include(p => p.PersonRace);
    }
}