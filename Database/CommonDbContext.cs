using Microsoft.EntityFrameworkCore;
using Models.Common;
using Models.Items;
using Models.LiveEntities;

namespace Database;

public class CommonDbContext : DbContext
{
    //common
    public DbSet<LiveEntityClass> Classes { get; private set; }
    public DbSet<LiveEntityRace> Races { get; private set; }
    public DbSet<DamageType> DamageTypes { get; private set; }
    public DbSet<SpellScroll> SpellScrolls { get; private set; }
    public DbSet<SpellComponent> SpellComponents { get; private set; }
    public DbSet<School> Schools { get; private set; }
    public DbSet<Spell> Spells { get; private set; }
    public DbSet<ItemType> ItemTypes { get; private set; }
    public DbSet<ItemRarity> ItemRarities { get; private set; }
    public DbSet<Item> Items { get; private set; }
    public DbSet<OtherItem> OtherItems { get; private set; }
    public DbSet<Characteristic> Characteristics { get; private set; }
    public DbSet<Backpack> Backpacks { get; private set; }

    public DbSet<Status> Statuses { get; private set; }

    public DbSet<NonPlayerCharacter> NonPlayerCharacters { get; private set; }
    public DbSet<Creature> Creatures { get; private set; }
    public DbSet<Person> Persons { get; private set; }

    public DbSet<Weapon> Weapons { get; private set; }

    public CommonDbContext(DbContextOptions<CommonDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Backpack>().HasMany<Item>(b => b.Items).WithOne();
        modelBuilder.Entity<Backpack>().HasMany<OtherItem>(b => b.OtherItems).WithOne();

        modelBuilder.Entity<Spell>().HasOne<School>(spell => spell.School);
        modelBuilder.Entity<Spell>().HasOne<DamageType>(spell => spell.DamageType);
        modelBuilder.Entity<Spell>().HasMany<LiveEntityClass>(spell => spell.AvailableClasses);
        modelBuilder.Entity<Spell>().HasMany<SpellComponent>(spell => spell.AvailableComponents);

        modelBuilder.Entity<NonPlayerCharacter>().HasMany<Characteristic>(npc => npc.Сharacteristics);
        modelBuilder.Entity<NonPlayerCharacter>().HasMany<Status>(npc => npc.Statuses);
        modelBuilder.Entity<NonPlayerCharacter>().HasMany<Spell>(npc => npc.Spells);

        modelBuilder.Entity<NonPlayerCharacter>().HasMany<Status>(npc => npc.Statuses);
        modelBuilder.Entity<NonPlayerCharacter>().HasMany<Characteristic>(npc => npc.Сharacteristics);
        modelBuilder.Entity<NonPlayerCharacter>().HasMany<Spell>(npc => npc.Spells);
        modelBuilder.Entity<NonPlayerCharacter>().HasOne<Backpack>(npc => npc.Backpack);

        modelBuilder.Entity<Person>().HasMany<Status>(person => person.Statuses);
        modelBuilder.Entity<Person>().HasMany<Characteristic>(person => person.Сharacteristics);
        modelBuilder.Entity<Person>().HasMany<Spell>(person => person.Spells);
        modelBuilder.Entity<Person>().HasOne<Backpack>(person => person.Backpack);

        modelBuilder.Entity<Creature>().HasMany<Status>(creature => creature.Statuses);
        modelBuilder.Entity<Creature>().HasMany<Characteristic>(creature => creature.Сharacteristics);
        modelBuilder.Entity<Creature>().HasMany<Spell>(creature => creature.Spells);

        modelBuilder.Entity<Item>().HasOne<ItemType>(item => item.Type);
        modelBuilder.Entity<Item>().HasOne<ItemRarity>(item => item.Rarity);

        modelBuilder.Entity<Weapon>().HasOne<DamageType>(item => item.DamageType);

        modelBuilder.Entity<SpellScroll>().HasOne<ItemType>(scroll => scroll.Type);
        modelBuilder.Entity<SpellScroll>().HasOne<ItemRarity>(scroll => scroll.Rarity);
        modelBuilder.Entity<SpellScroll>().HasOne<Spell>(scroll => scroll.Spell);
    }
}