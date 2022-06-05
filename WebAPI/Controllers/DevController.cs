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

    public DevController(CommonDbContext commonDbContext)
    {
        _commonDbContext = commonDbContext;
    }

    [HttpGet("/create-db")]
    public IActionResult CreateDb()
    {
        try
        {
            _commonDbContext.Database.EnsureDeleted();

            _commonDbContext.Database.EnsureCreated();

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
                _commonDbContext.DamageTypes,
                type => new DamageType()
                {
                    Id = Guid.NewGuid(),
                    Name = type.ToString(),
                    EType = type
                }
            );

            FillTypedEntities<ItemRarity, ItemRarity.Rarity>(
                _commonDbContext.ItemRarities,
                type => new ItemRarity()
                {
                    Id = Guid.NewGuid(),
                    Name = type.ToString(),
                    ERarity = type,
                    Modifier = 0
                }
            );

            FillTypedEntities<ItemType, ItemType.Type>(
                _commonDbContext.ItemTypes,
                type => new ItemType()
                {
                    Id = Guid.NewGuid(),
                    Name = type.ToString(),
                    EType = type
                }
            );

            FillTypedEntities<LiveEntityClass, LiveEntityClass.Type>(
                _commonDbContext.Classes,
                type => new LiveEntityClass()
                {
                    Id = Guid.NewGuid(),
                    Name = type.ToString(),
                    EType = type
                }
            );

            FillTypedEntities<LiveEntityRace, LiveEntityRace.Race>(
                _commonDbContext.Races,
                type => new LiveEntityRace()
                {
                    Id = Guid.NewGuid(),
                    Name = type.ToString(),
                    ERace = type
                }
            );

            FillTypedEntities<Status, Status.Type>(
                _commonDbContext.Statuses,
                type => new Status()
                {
                    Id = Guid.NewGuid(),
                    Name = type.ToString(),
                    EType = type,
                    Description = "",
                    ImageSource = ""
                }
            );

            _commonDbContext.SaveChanges();

            return Json(new {result = "ok"});
        }
        catch (Exception e)
        {
            return StatusCode(500, new {result = e.Message});
        }
    }

    private void FillTypedEntities<TEntity, TEnum>(DbSet<TEntity> dbSet, Func<TEnum, TEntity> entityProducer)
        where TEntity : class
        where TEnum : Enum
    {
        foreach (TEnum type in Enum.GetValues(typeof(TEnum)))
        {
            dbSet.Add(entityProducer(type));
        }
    }
}