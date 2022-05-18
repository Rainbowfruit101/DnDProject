using Microsoft.EntityFrameworkCore;
using Models;
using Models.LiveEntities;

namespace Database;

public class DnDDatabaseContext: DbContext
{
    public DbSet<LiveEntityClass> Classes { get; private set; }
    
    public DnDDatabaseContext(DbContextOptions<DnDDatabaseContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public LiveEntityClass? FindByType(LiveEntityClass.ClassType type)
    {
        return Classes.FirstOrDefault(c => c.EClassType == type);
    }
}