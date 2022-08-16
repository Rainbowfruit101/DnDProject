using Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Common;
using Models.Enums;
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

    [HttpGet("create-db")]
    public IActionResult CreateDb()
    {
        try
        {
            _commonDbContext.Database.EnsureDeleted();

            _commonDbContext.Database.EnsureCreated();

            FillTypedEntities<School, SchoolType>(
                _commonDbContext.Schools,
                type => new School()
                {
                    Id = Guid.NewGuid(),
                    Name = type.ToString(),
                    Type = type
                }
            );

            FillTypedEntities<DamageType, DamageEType>(
                _commonDbContext.DamageTypes,
                type => new DamageType()
                {
                    Id = Guid.NewGuid(),
                    Name = type.ToString(),
                    Type = type,
                    Description = ""
                }
            );

            FillTypedEntities<ItemRarity, RarityType>(
                _commonDbContext.ItemRarities,
                type => new ItemRarity()
                {
                    Id = Guid.NewGuid(),
                    Name = type.ToString(),
                    Type = type,
                    Modifier = 0
                }
            );

            FillTypedEntities<ItemType, ItemEType>(
                _commonDbContext.ItemTypes,
                type => new ItemType()
                {
                    Id = Guid.NewGuid(),
                    Name = type.ToString(),
                    Type = type
                }
            );

            FillTypedEntities<LiveEntityClass, ClassType>(
                _commonDbContext.Classes,
                type => new LiveEntityClass()
                {
                    Id = Guid.NewGuid(),
                    Name = type.ToString(),
                    Type = type
                }
            );

            FillTypedEntities<LiveEntityRace, RaceType>(
                _commonDbContext.Races,
                type => new LiveEntityRace()
                {
                    Id = Guid.NewGuid(),
                    Name = type.ToString(),
                    Type = type
                }
            );

            FillTypedEntities<Status, StatusType>(
                _commonDbContext.Statuses,
                type => new Status()
                {
                    Id = Guid.NewGuid(),
                    Name = type.ToString(),
                    Type = type,
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