using Microsoft.EntityFrameworkCore;
using Models.Common;

namespace Database;

public class CommonDbContext : DbContext
{
    public DbSet<Characteristic> Characteristics { get; private set; }
    public DbSet<Status> Statuses { get; private set; }
    public DbSet<Backpack> Backpacks { get; private set; }

    public DbSet<Spell> Spells { get; private set; }
    public DbSet<SpellComponent> SpellComponents { get; private set; }

    public CommonDbContext(DbContextOptions<CommonDbContext> options) : base(options)
    {
    }
}