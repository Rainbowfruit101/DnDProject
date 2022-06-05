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
        modelBuilder.Entity<Backpack>()
            .HasMany<Item>(b => b.Items)
            .WithMany(item => item.Backpacks);
        modelBuilder.Entity<Backpack>()
            .HasMany<OtherItem>(b => b.OtherItems)
            .WithMany(item => item.Backpacks);

        modelBuilder.Entity<Spell>()
            .HasOne<School>(spell => spell.School)
            .WithMany();
        modelBuilder.Entity<Spell>()
            .HasOne<DamageType>(spell => spell.DamageType)
            .WithMany();
        modelBuilder.Entity<Spell>()
            .HasMany<LiveEntityClass>(spell => spell.AvailableClasses)
            .WithMany(leClass => leClass.Spells);
        modelBuilder.Entity<Spell>()
            .HasMany<SpellComponent>(spell => spell.AvailableComponents)
            .WithMany(component => component.Spells);

        modelBuilder.Entity<NonPlayerCharacter>()
            .HasMany<Characteristic>(npc => npc.Сharacteristics)
            .WithMany(characteristic => characteristic.NonPlayerCharacters);
        modelBuilder.Entity<NonPlayerCharacter>()
            .HasMany<Status>(npc => npc.Statuses)
            .WithMany(status => status.NonPlayerCharacters);
        modelBuilder.Entity<NonPlayerCharacter>()
            .HasMany<Spell>(npc => npc.Spells)
            .WithMany(spell => spell.NonPlayerCharacters );
        modelBuilder.Entity<NonPlayerCharacter>()
            .HasOne<Backpack>(npc => npc.Backpack)
            .WithOne().HasForeignKey<NonPlayerCharacter>();
        modelBuilder.Entity<NonPlayerCharacter>()
            .HasOne<LiveEntityRace>(npc => npc.PersonRace)
            .WithMany();
        modelBuilder.Entity<NonPlayerCharacter>()
            .HasOne<LiveEntityClass>(npc => npc.PersonClass)
            .WithMany();

        modelBuilder.Entity<Person>()
            .HasMany<Status>(person => person.Statuses)
            .WithMany(status => status.Persons);
        modelBuilder.Entity<Person>()
            .HasMany<Characteristic>(person => person.Сharacteristics)
            .WithMany(characteristic => characteristic.Persons);
        modelBuilder.Entity<Person>()
            .HasMany<Spell>(person => person.Spells)
            .WithMany(spell => spell.Persons);
        modelBuilder.Entity<Person>()
            .HasOne<Backpack>(person => person.Backpack)
            .WithOne().HasForeignKey<Person>();
        modelBuilder.Entity<Person>()
            .HasOne<LiveEntityRace>(person => person.PersonRace)
            .WithMany();
        modelBuilder.Entity<Person>()
            .HasOne<LiveEntityClass>(person => person.PersonClass)
            .WithMany();
        modelBuilder.Entity<Person>()
            .HasMany<LiveEntityClass>(person => person.MultiClasses)
            .WithMany(leClass => leClass.Persons);
        modelBuilder.Entity<Person>()
            .Ignore(person => person.AllClasses);

        modelBuilder.Entity<Creature>()
            .HasMany<Status>(creature => creature.Statuses)
            .WithMany(status => status.Creatures);
        modelBuilder.Entity<Creature>()
            .HasMany<Characteristic>(creature => creature.Сharacteristics)
            .WithMany(characteristic => characteristic.Creatures);
        modelBuilder.Entity<Creature>()
            .HasMany<Spell>(creature => creature.Spells)
            .WithMany(spell => spell.Creatures);
        modelBuilder.Entity<Creature>()
            .HasOne<LiveEntityRace>(creature => creature.PersonRace)
            .WithMany();
        modelBuilder.Entity<Creature>()
            .HasOne<LiveEntityClass>(creature => creature.PersonClass)
            .WithMany();

        modelBuilder.Entity<Item>()
            .HasOne<ItemType>(item => item.Type)
            .WithMany();
        modelBuilder.Entity<Item>()
            .HasOne<ItemRarity>(item => item.Rarity)
            .WithMany();

        modelBuilder.Entity<Weapon>()
            .HasOne<DamageType>(item => item.DamageType)
            .WithMany();

        modelBuilder.Entity<SpellScroll>()
            .HasOne<ItemType>(scroll => scroll.Type)
            .WithMany();
        modelBuilder.Entity<SpellScroll>()
            .HasOne<ItemRarity>(scroll => scroll.Rarity)
            .WithMany();
        modelBuilder.Entity<SpellScroll>()
            .HasOne<Spell>(scroll => scroll.Spell)
            .WithMany();

        base.OnModelCreating(modelBuilder);
    }
}