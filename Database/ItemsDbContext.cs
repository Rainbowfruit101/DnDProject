using Microsoft.EntityFrameworkCore;
using Models.Items;

namespace Database;

public class ItemsDbContext : DbContext
{
    public DbSet<ItemType> ItemTypes { get; private set; }
    public DbSet<DamageType> DamageTypes { get; private set; }
    public DbSet<ItemRarity> ItemRarities { get; private set; }

    public DbSet<Item> Items { get; private set; }
    public DbSet<Weapon> Weapons { get; private set; }
    public DbSet<SpellScroll> SpellScrolls { get; private set; }

    public ItemsDbContext(DbContextOptions<ItemsDbContext> options) : base(options)
    {
    }
}