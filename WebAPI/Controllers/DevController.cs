using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Common;
using Models.Interfaces;
using Models.Items;
using Models.LiveEntities;

namespace WebAPI.Controllers;

[Route("/dev")]
public class DevController : Controller
{
    private readonly CommonDbContext _commonDbContext;
    private readonly LiveEntitiesDbContext _liveEntitiesDbContext;
    private readonly ItemsDbContext _itemsDbContext;

    public DevController(CommonDbContext commonDbContext, LiveEntitiesDbContext liveEntitiesDbContext,
        ItemsDbContext itemsDbContext)
    {
        _commonDbContext = commonDbContext;
        _liveEntitiesDbContext = liveEntitiesDbContext;
        _itemsDbContext = itemsDbContext;
    }

    [HttpGet("/create-db")]
    public IActionResult CreateDb()
    {
        string resultText;
        try
        {
            _liveEntitiesDbContext.Database.EnsureDeleted();
            _commonDbContext.Database.EnsureDeleted();
            _itemsDbContext.Database.EnsureDeleted();

            _liveEntitiesDbContext.Database.EnsureCreated();
            _commonDbContext.Database.EnsureCreated();
            _itemsDbContext.Database.EnsureCreated();

            FillTypedEntities<School, School.Type>(
                _commonDbContext.Schools,
                type => new School()
                {
                    Id = Guid.NewGuid(),
                    Name = type.ToString(),
                    EType = type
                }
            );

            FillTypedEntities<DamageType, DamageType.Type>(
                _itemsDbContext.DamageTypes,
                type => new DamageType()
                {
                    Id = Guid.NewGuid(),
                    Name = type.ToString(),
                    EType = type
                }
            );

            FillTypedEntities<ItemRarity, ItemRarity.Rarity>(
                _itemsDbContext.ItemRarities,
                type => new ItemRarity()
                {
                    Id = Guid.NewGuid(),
                    Name = type.ToString(),
                    ERarity = type,
                    Modifier = 0
                }
            );

            FillTypedEntities<ItemType, ItemType.Type>(
                _itemsDbContext.ItemTypes,
                type => new ItemType()
                {
                    Id = Guid.NewGuid(),
                    Name = type.ToString(),
                    EType = type
                }
            );

            FillTypedEntities<LiveEntityClass, LiveEntityClass.Type>(
                _liveEntitiesDbContext.Classes,
                type => new LiveEntityClass()
                {
                    Id = Guid.NewGuid(),
                    Name = type.ToString(),
                    EType = type
                }
            );

            FillTypedEntities<LiveEntityRace, LiveEntityRace.Race>(
                _liveEntitiesDbContext.Races,
                type => new LiveEntityRace()
                {
                    Id = Guid.NewGuid(),
                    Name = type.ToString(),
                    ERace = type
                }
            );

            FillTypedEntities<Status, Status.Type>(
                _liveEntitiesDbContext.Statuses,
                type => new Status()
                {
                    Id = Guid.NewGuid(),
                    Name = type.ToString(),
                    EType = type,
                    Description = "",
                    ImageSource = ""
                }
            );

            _liveEntitiesDbContext.SaveChanges();
            _commonDbContext.SaveChanges();
            _itemsDbContext.SaveChanges();

            resultText = "ok";
        }
        catch (Exception e)
        {
            resultText = e.Message;
        }

        return Json(new {result = resultText});
    }

    private void FillTypedEntities<TEntity, TEnum>(DbSet<TEntity> dbSet, Func<TEnum, TEntity> entityProducer)
        where TEntity : class, IIdentifiable, new()
        where TEnum : Enum
    {
        dbSet.RemoveAll();

        foreach (TEnum type in Enum.GetValues(typeof(TEnum)))
        {
            dbSet.Add(entityProducer(type));
        }
    }
}