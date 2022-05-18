using Microsoft.EntityFrameworkCore;
using Models.LiveEntities;

namespace Database;

public class LiveEntitiesDbContext : DbContext
{
    public DbSet<LiveEntityClass> Classes { get; private set; }
    public DbSet<LiveEntityRace> Races { get; private set; }
    public DbSet<Status> Statuses { get; private set; }

    public DbSet<NonPlayerCharacter> NonPlayerCharacters { get; private set; }
    public DbSet<Creature> Creatures { get; private set; }
    public DbSet<Person> Persons { get; private set; }

    public LiveEntitiesDbContext(DbContextOptions<LiveEntitiesDbContext> options) : base(options)
    {
    }
}